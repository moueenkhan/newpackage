// <copyright file="RestApiClientClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace RestApiClient.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using RestApiClient.Standard.Authentication;
    using RestApiClient.Standard.Controllers;
    using RestApiClient.Standard.Http.Client;
    using RestApiClient.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class RestApiClientClient : IRestApiClientClient
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Server, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Server, string>>
        {
            {
                Environment.Production, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api.earthport.com/v1" },
                    { Server.Auth, "https://api.earthport.com" },
                }
            },
            {
                Environment.Sandbox, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api-sandbox.earthport.com/v1" },
                    { Server.Auth, "https://api-sandbox.earthport.com" },
                }
            },
            {
                Environment.CustomerIntegration, new Dictionary<Server, string>
                {
                    { Server.Default, "https://api-integration.earthport.com/v1" },
                    { Server.Auth, "https://api-integration.earthport.com" },
                }
            },
        };

        private readonly IDictionary<string, IAuthManager> authManagers;
        private readonly IHttpClient httpClient;
        private readonly HttpCallBack httpCallBack;
        private readonly BearerAuthManager bearerAuthManager;

        private readonly Lazy<IUsersController> users;
        private readonly Lazy<IPaymentsController> payments;
        private readonly Lazy<IAuthenticationController> authentication;
        private readonly Lazy<IBeneficiaryBankAccountsController> beneficiaryBankAccounts;
        private readonly Lazy<IQuotesController> quotes;
        private readonly Lazy<ITransactionsController> transactions;
        private readonly Lazy<ISettlementCalendarsController> settlementCalendars;
        private readonly Lazy<IBalancesController> balances;
        private readonly Lazy<IStatementsController> statements;

        private RestApiClientClient(
            Environment environment,
            string accessToken,
            IDictionary<string, IAuthManager> authManagers,
            IHttpClient httpClient,
            HttpCallBack httpCallBack,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.httpCallBack = httpCallBack;
            this.httpClient = httpClient;
            this.authManagers = (authManagers == null) ? new Dictionary<string, IAuthManager>() : new Dictionary<string, IAuthManager>(authManagers);
            this.HttpClientConfiguration = httpClientConfiguration;

            this.users = new Lazy<IUsersController>(
                () => new UsersController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.payments = new Lazy<IPaymentsController>(
                () => new PaymentsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.authentication = new Lazy<IAuthenticationController>(
                () => new AuthenticationController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.beneficiaryBankAccounts = new Lazy<IBeneficiaryBankAccountsController>(
                () => new BeneficiaryBankAccountsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.quotes = new Lazy<IQuotesController>(
                () => new QuotesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.transactions = new Lazy<ITransactionsController>(
                () => new TransactionsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.settlementCalendars = new Lazy<ISettlementCalendarsController>(
                () => new SettlementCalendarsController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.balances = new Lazy<IBalancesController>(
                () => new BalancesController(this, this.httpClient, this.authManagers, this.httpCallBack));
            this.statements = new Lazy<IStatementsController>(
                () => new StatementsController(this, this.httpClient, this.authManagers, this.httpCallBack));

            if (this.authManagers.ContainsKey("global"))
            {
                this.bearerAuthManager = (BearerAuthManager)this.authManagers["global"];
            }

            if (!this.authManagers.ContainsKey("global")
                || !this.BearerAuthCredentials.Equals(accessToken))
            {
                this.bearerAuthManager = new BearerAuthManager(accessToken);
                this.authManagers["global"] = this.bearerAuthManager;
            }
        }

        /// <summary>
        /// Gets UsersController controller.
        /// </summary>
        public IUsersController UsersController => this.users.Value;

        /// <summary>
        /// Gets PaymentsController controller.
        /// </summary>
        public IPaymentsController PaymentsController => this.payments.Value;

        /// <summary>
        /// Gets AuthenticationController controller.
        /// </summary>
        public IAuthenticationController AuthenticationController => this.authentication.Value;

        /// <summary>
        /// Gets BeneficiaryBankAccountsController controller.
        /// </summary>
        public IBeneficiaryBankAccountsController BeneficiaryBankAccountsController => this.beneficiaryBankAccounts.Value;

        /// <summary>
        /// Gets QuotesController controller.
        /// </summary>
        public IQuotesController QuotesController => this.quotes.Value;

        /// <summary>
        /// Gets TransactionsController controller.
        /// </summary>
        public ITransactionsController TransactionsController => this.transactions.Value;

        /// <summary>
        /// Gets SettlementCalendarsController controller.
        /// </summary>
        public ISettlementCalendarsController SettlementCalendarsController => this.settlementCalendars.Value;

        /// <summary>
        /// Gets BalancesController controller.
        /// </summary>
        public IBalancesController BalancesController => this.balances.Value;

        /// <summary>
        /// Gets StatementsController controller.
        /// </summary>
        public IStatementsController StatementsController => this.statements.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }

        /// <summary>
        /// Gets auth managers.
        /// </summary>
        internal IDictionary<string, IAuthManager> AuthManagers => this.authManagers;

        /// <summary>
        /// Gets http client.
        /// </summary>
        internal IHttpClient HttpClient => this.httpClient;

        /// <summary>
        /// Gets http callback.
        /// </summary>
        internal HttpCallBack HttpCallBack => this.httpCallBack;

        /// <summary>
        /// Gets the credentials to use with BearerAuth.
        /// </summary>
        private IBearerAuthCredentials BearerAuthCredentials => this.bearerAuthManager;

        /// <summary>
        /// Gets the access token to use with OAuth 2 authentication.
        /// </summary>
        public string AccessToken => this.BearerAuthCredentials.AccessToken;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            StringBuilder url = new StringBuilder(EnvironmentsMap[this.Environment][alias]);
            ApiHelper.AppendUrlWithTemplateParameters(url, this.GetBaseUriParameters());

            return url.ToString();
        }

        /// <summary>
        /// Creates an object of the RestApiClientClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .AccessToken(this.BearerAuthCredentials.AccessToken)
                .HttpCallBack(this.httpCallBack)
                .HttpClient(this.httpClient)
                .AuthManagers(this.authManagers)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> RestApiClientClient.</returns>
        internal static RestApiClientClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("REST_API_CLIENT_STANDARD_ENVIRONMENT");
            string accessToken = System.Environment.GetEnvironmentVariable("REST_API_CLIENT_STANDARD_ACCESS_TOKEN");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (accessToken != null)
            {
                builder.AccessToken(accessToken);
            }

            return builder.Build();
        }

        /// <summary>
        /// Makes a list of the BaseURL parameters.
        /// </summary>
        /// <returns>Returns the parameters list.</returns>
        private List<KeyValuePair<string, object>> GetBaseUriParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList;
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = RestApiClient.Standard.Environment.Sandbox;
            private string accessToken = "";
            private IDictionary<string, IAuthManager> authManagers = new Dictionary<string, IAuthManager>();
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();
            private IHttpClient httpClient;
            private HttpCallBack httpCallBack;

            /// <summary>
            /// Sets credentials for BearerAuth.
            /// </summary>
            /// <param name="accessToken">AccessToken.</param>
            /// <returns>Builder.</returns>
            public Builder AccessToken(string accessToken)
            {
                this.accessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

            /// <summary>
            /// Sets the IHttpClient for the Builder.
            /// </summary>
            /// <param name="httpClient"> http client. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpClient(IHttpClient httpClient)
            {
                this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
                return this;
            }

            /// <summary>
            /// Sets the authentication managers for the Builder.
            /// </summary>
            /// <param name="authManagers"> auth managers. </param>
            /// <returns>Builder.</returns>
            internal Builder AuthManagers(IDictionary<string, IAuthManager> authManagers)
            {
                this.authManagers = authManagers ?? throw new ArgumentNullException(nameof(authManagers));
                return this;
            }

            /// <summary>
            /// Sets the HttpCallBack for the Builder.
            /// </summary>
            /// <param name="httpCallBack"> http callback. </param>
            /// <returns>Builder.</returns>
            internal Builder HttpCallBack(HttpCallBack httpCallBack)
            {
                this.httpCallBack = httpCallBack;
                return this;
            }

            /// <summary>
            /// Creates an object of the RestApiClientClient using the values provided for the builder.
            /// </summary>
            /// <returns>RestApiClientClient.</returns>
            public RestApiClientClient Build()
            {
                this.httpClient = new HttpClientWrapper(this.httpClientConfig.Build());

                return new RestApiClientClient(
                    this.environment,
                    this.accessToken,
                    this.authManagers,
                    this.httpClient,
                    this.httpCallBack,
                    this.httpClientConfig.Build());
            }
        }
    }
}

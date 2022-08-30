
# Requested FX Enum

Method of FX that is requested by the merchant and for which EPS2 will attempt to use in order to settle the payout request.

## Enumeration

`RequestedFXEnum`

## Fields

| Name | Description |
|  --- | --- |
| `FF` | (Fixed to Fixed) is where no FX will be performed as payout and beneficiary currencies are the same. |
| `FV` | FV (Fixed to Variable) uses the supplied payout request amount in order to determine the beneficiary amount. |
| `VF` | VF (Variable to Fixed) uses the supplied beneficiary amount in order to determine the payout amount. |


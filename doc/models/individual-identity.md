
# Individual Identity

The identity of an individual. The 'name' attribute is mandatory for an individual. You must supply at least identification entry or one birth information entry or one address entry.

## Structure

`IndividualIdentity`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Name` | [`Models.IndividualName`](../../doc/models/individual-name.md) | Required | The 'givenNames' attribute is mandatory. This is a space separated list of names (not including the family name).<br><br>You should supply names and not initials (wherever possible). See examples below.<br><br>The 'familyName' attribute is mandatory. This contains the single family name. See examples below.<br><br>*Example1 - a western citizen from a country which uses the common western naming convention(such as US, GB, FR, CA, DE etc...)*<br><br>    Name = "John Michael Smith",<br>    <br>    givenNames="John Michael" and familyName="Smith"<br><br>*Example2 - a citizen from a country which uses the eastern name order where the family name comes first, followed by their given names (such as Hungary, China, Japan, Korea, Singapore, Taiwan, Vietnam etc...)*<br><br>    Name = "Máo Zédÿng",<br>    <br>    givenNames="Zédÿng" and familyName="Máo"<br>    <br>    <br>    Name = "Hidetoshi Nakata",<br>    <br>    givenNames="Nakata" and familyName="Hidetoshi"<br>    <br>    <br>    Name = "Ferenc Puskás",<br>    <br>    givenNames="Puskás" and familyName="Ferenc"<br><br>*Example3 - middle east names*<br><br>    Name= "Mohammed bin Rashid bin Saeed Al-Maktoum",<br>    <br>    givenNames="Mohammed bin Rashid bin Saeed" and familyName="Al-Maktoum"<br><br>*Example4 - single names, such as in Indonesia*<br><br>    Name="Suharto",<br>    <br>    givenNames="Suharto" and familyName="Suharto". |
| `Address` | [`Models.Address`](../../doc/models/address.md) | Optional | Represents an address. Mandatory attributes are 'addressLine1', 'city' and 'country'. All other attributes are optional. |
| `BirthInformation` | [`Models.BirthInformation`](../../doc/models/birth-information.md) | Optional | The group consists of elements that define birth information for an individual. |
| `Identification` | [`List<Models.Identification>`](../../doc/models/identification.md) | Optional | This group consists of an individual identification unique number and the country of origin of the identification. |

## Example (as JSON)

```json
{
  "name": {
    "familyName": "Smith",
    "givenNames": "John"
  }
}
```


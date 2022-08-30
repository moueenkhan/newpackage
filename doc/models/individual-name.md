
# Individual Name

The 'givenNames' attribute is mandatory. This is a space separated list of names (not including the family name).

You should supply names and not initials (wherever possible). See examples below.

The 'familyName' attribute is mandatory. This contains the single family name. See examples below.

*Example1 - a western citizen from a country which uses the common western naming convention(such as US, GB, FR, CA, DE etc...)*

    Name = "John Michael Smith",
    
    givenNames="John Michael" and familyName="Smith"

*Example2 - a citizen from a country which uses the eastern name order where the family name comes first, followed by their given names (such as Hungary, China, Japan, Korea, Singapore, Taiwan, Vietnam etc...)*

    Name = "Máo Zédÿng",
    
    givenNames="Zédÿng" and familyName="Máo"
    
    
    Name = "Hidetoshi Nakata",
    
    givenNames="Nakata" and familyName="Hidetoshi"
    
    
    Name = "Ferenc Puskás",
    
    givenNames="Puskás" and familyName="Ferenc"

*Example3 - middle east names*

    Name= "Mohammed bin Rashid bin Saeed Al-Maktoum",
    
    givenNames="Mohammed bin Rashid bin Saeed" and familyName="Al-Maktoum"

*Example4 - single names, such as in Indonesia*

    Name="Suharto",
    
    givenNames="Suharto" and familyName="Suharto".

## Structure

`IndividualName`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `FamilyName` | `string` | Required | The family name component of an individual's identity. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1024` |
| `GivenNames` | `string` | Required | The given names component of an individual's identity. For detailed examples see documentation for type IndividualName. The length of this field is limited to 1024 bytes. 1024 bytes can hold 1024 normal English characters.<br>**Constraints**: *Minimum Length*: `1`, *Maximum Length*: `1024` |

## Example (as JSON)

```json
{
  "familyName": "Smith",
  "givenNames": "John"
}
```


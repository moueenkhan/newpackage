
# Pagination Result

This returns a paged set of results rather than the full result set.

## Structure

`PaginationResult`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `Offset` | `int` | Required | 0-based starting offset of the page with respect to the entire resultset. |
| `PageSize` | `int?` | Optional | Number of items per page to return. If empty the maximum allowable (25) number of records will be returned. |
| `TotalNumberOfRecords` | `int` | Required | Total number of records in full result set. |

## Example (as JSON)

```json
{
  "offset": 12,
  "pageSize": null,
  "totalNumberOfRecords": 32
}
```


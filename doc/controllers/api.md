# API

```csharp
APIController aPIController = client.APIController;
```

## Class Name

`APIController`


# Get Items by Status

Retrieve a list of items based on their status.

```csharp
GetItemsByStatusAsync(
    Models.StatusEnum status)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `status` | [`StatusEnum`](../../doc/models/status-enum.md) | Template, Required | The status of the items to filter by. |

## Response Type

[`Task<List<Models.ItemsResponse>>`](../../doc/models/items-response.md)

## Example Usage

```csharp
StatusEnum status = StatusEnum.Pending;
try
{
    List<ItemsResponse> result = await aPIController.GetItemsByStatusAsync(status);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Bad request, possibly due to an invalid status value. | `ApiException` |
| 404 | No items found for the given status. | `ApiException` |


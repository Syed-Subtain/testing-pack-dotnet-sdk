
# Getting Started with Enum as Template Parameter Example API

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package TestingPackSDK --version 6.6.666
```

You can also view the package at:
https://www.nuget.org/packages/TestingPackSDK/6.6.666

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/client.md)

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `DefaultHost` | `string` | *Default*: `"www.example.com"` |
| `Environment` | `Environment` | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |

The API client can be initialized as follows:

```csharp
EnumAsTemplateParameterExampleAPI.Standard.EnumAsTemplateParameterExampleAPIClient client = new EnumAsTemplateParameterExampleAPI.Standard.EnumAsTemplateParameterExampleAPIClient.Builder()
    .Environment(EnumAsTemplateParameterExampleAPI.Standard.Environment.Production)
    .DefaultHost("www.example.com")
    .Build();
```

## List of APIs

* [API](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/controllers/api.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-request.md)
* [HttpResponse](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-string-response.md)
* [HttpContext](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/Syed-Subtain/testing-pack-dotnet-sdk/tree/6.6.666/doc/api-exception.md)


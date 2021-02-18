# ExpertIO.Client.Api.ContextsApi

All URIs are relative to *https://nlapi.expert.ai/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ContextsGet**](ContextsApi.md#contextsget) | **GET** /contexts | Contexts information



## ContextsGet

> ContextsResponse ContextsGet ()

Contexts information

Information about available contexts

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class ContextsGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new ContextsApi(Configuration.Default);

            try
            {
                // Contexts information
                ContextsResponse result = apiInstance.ContextsGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling ContextsApi.ContextsGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ContextsResponse**](ContextsResponse.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Resource response |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **500** | Internal Server Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


# ExpertIO.Client.Api.TaxonomiesApi

All URIs are relative to *https://nlapi.expert.ai/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**TaxonomiesGet**](TaxonomiesApi.md#taxonomiesget) | **GET** /taxonomies | Taxonomies information
[**TaxonomiesTaxonomyLanguageGet**](TaxonomiesApi.md#taxonomiestaxonomylanguageget) | **GET** /taxonomies/{taxonomy}/{language} | Taxonomy tree



## TaxonomiesGet

> TaxonomiesResponse TaxonomiesGet ()

Taxonomies information

Information about available taxonomies

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class TaxonomiesGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TaxonomiesApi(Configuration.Default);

            try
            {
                // Taxonomies information
                TaxonomiesResponse result = apiInstance.TaxonomiesGet();
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TaxonomiesApi.TaxonomiesGet: " + e.Message );
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

[**TaxonomiesResponse**](TaxonomiesResponse.md)

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


## TaxonomiesTaxonomyLanguageGet

> TaxonomyResponse TaxonomiesTaxonomyLanguageGet (string taxonomy, string language)

Taxonomy tree

Detailed information about a taxonomy for a given language

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class TaxonomiesTaxonomyLanguageGetExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new TaxonomiesApi(Configuration.Default);
            var taxonomy = taxonomy_example;  // string | Taxonomy name
            var language = language_example;  // string | Taxonomy language (code); use the `taxonomies` resource to discover the languages that the taxonomy supports

            try
            {
                // Taxonomy tree
                TaxonomyResponse result = apiInstance.TaxonomiesTaxonomyLanguageGet(taxonomy, language);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling TaxonomiesApi.TaxonomiesTaxonomyLanguageGet: " + e.Message );
                Debug.Print("Status Code: "+ e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

### Parameters


Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **taxonomy** | **string**| Taxonomy name | 
 **language** | **string**| Taxonomy language (code); use the &#x60;taxonomies&#x60; resource to discover the languages that the taxonomy supports | 

### Return type

[**TaxonomyResponse**](TaxonomyResponse.md)

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


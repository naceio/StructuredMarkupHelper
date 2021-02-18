# ExpertIO.Client.Api.DocumentClassificationApi

All URIs are relative to *https://nlapi.expert.ai/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CategorizeTaxonomyLanguagePost**](DocumentClassificationApi.md#categorizetaxonomylanguagepost) | **POST** /categorize/{taxonomy}/{language} | Classification



## CategorizeTaxonomyLanguagePost

> CategorizeResponse CategorizeTaxonomyLanguagePost (string taxonomy, string language, AnalysisRequest analysisRequest = null)

Classification

Classification of the posted text

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class CategorizeTaxonomyLanguagePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DocumentClassificationApi(Configuration.Default);
            var taxonomy = taxonomy_example;  // string | Taxonomy name; use the `taxonomies` resource to discover available taxonomies
            var language = language_example;  // string | Document language (code); use the `taxonomies` resource to discover the languages for which the taxonomy is available
            var analysisRequest = new AnalysisRequest(); // AnalysisRequest | The document to be classified (optional) 

            try
            {
                // Classification
                CategorizeResponse result = apiInstance.CategorizeTaxonomyLanguagePost(taxonomy, language, analysisRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DocumentClassificationApi.CategorizeTaxonomyLanguagePost: " + e.Message );
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
 **taxonomy** | **string**| Taxonomy name; use the &#x60;taxonomies&#x60; resource to discover available taxonomies | 
 **language** | **string**| Document language (code); use the &#x60;taxonomies&#x60; resource to discover the languages for which the taxonomy is available | 
 **analysisRequest** | [**AnalysisRequest**](AnalysisRequest.md)| The document to be classified | [optional] 

### Return type

[**CategorizeResponse**](CategorizeResponse.md)

### Authorization

[bearerAuth](../README.md#bearerAuth)

### HTTP request headers

- **Content-Type**: application/json
- **Accept**: application/json

### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Resource response |  -  |
| **401** | Unauthorized |  -  |
| **403** | Forbidden |  -  |
| **404** | Not Found |  -  |
| **413** | Request Entity Too Large |  -  |
| **500** | Internal Server Error |  -  |

[[Back to top]](#)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to Model list]](../README.md#documentation-for-models)
[[Back to README]](../README.md)


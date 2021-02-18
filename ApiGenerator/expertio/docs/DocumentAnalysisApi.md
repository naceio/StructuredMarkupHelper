# ExpertIO.Client.Api.DocumentAnalysisApi

All URIs are relative to *https://nlapi.expert.ai/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AnalyzeContextLanguageAnalysisPost**](DocumentAnalysisApi.md#analyzecontextlanguageanalysispost) | **POST** /analyze/{context}/{language}/{analysis} | Specific analysis
[**AnalyzeContextLanguagePost**](DocumentAnalysisApi.md#analyzecontextlanguagepost) | **POST** /analyze/{context}/{language} | Full analysis



## AnalyzeContextLanguageAnalysisPost

> AnalyzeResponse AnalyzeContextLanguageAnalysisPost (string context, string language, string analysis, AnalysisRequest analysisRequest = null)

Specific analysis

Specific analysis of the posted text. Available analyses are: <ul>   <li><strong>disambiguation</strong>: linguistic analysis (text subdivision, part-of-speech tagging, morphological analysis, lemmatization, syntactic analysis and semantic analysis)</li>   <li><strong>relevants</strong>: keyphrase extraction</li>   <li><strong>entities</strong>: named entity recognition</li>   <li><strong>relations</strong>: relation extraction</li>   <li><strong>sentiment</strong>: sentiment analysis</li> </ul> 

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class AnalyzeContextLanguageAnalysisPostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DocumentAnalysisApi(Configuration.Default);
            var context = context_example;  // string | Context name; use the `contexts` resource to discover available contexts
            var language = language_example;  // string | Document language (code)
            var analysis = analysis_example;  // string | Analysis name; use the `contexts` resource to determine if the context provides that analysis for the chosen language
            var analysisRequest = new AnalysisRequest(); // AnalysisRequest | The document to be analyzed (optional) 

            try
            {
                // Specific analysis
                AnalyzeResponse result = apiInstance.AnalyzeContextLanguageAnalysisPost(context, language, analysis, analysisRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DocumentAnalysisApi.AnalyzeContextLanguageAnalysisPost: " + e.Message );
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
 **context** | **string**| Context name; use the &#x60;contexts&#x60; resource to discover available contexts | 
 **language** | **string**| Document language (code) | 
 **analysis** | **string**| Analysis name; use the &#x60;contexts&#x60; resource to determine if the context provides that analysis for the chosen language | 
 **analysisRequest** | [**AnalysisRequest**](AnalysisRequest.md)| The document to be analyzed | [optional] 

### Return type

[**AnalyzeResponse**](AnalyzeResponse.md)

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


## AnalyzeContextLanguagePost

> AnalyzeResponse AnalyzeContextLanguagePost (string context, string language, AnalysisRequest analysisRequest = null)

Full analysis

Full analysis (i.e., sum of all available analyses) of the posted text

### Example

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;

namespace Example
{
    public class AnalyzeContextLanguagePostExample
    {
        public static void Main()
        {
            Configuration.Default.BasePath = "https://nlapi.expert.ai/v2";
            // Configure HTTP bearer authorization: bearerAuth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            var apiInstance = new DocumentAnalysisApi(Configuration.Default);
            var context = context_example;  // string | Context name; use the `contexts` resource to discover available contexts
            var language = language_example;  // string | Document language (code)
            var analysisRequest = new AnalysisRequest(); // AnalysisRequest | The document to be analyzed (optional) 

            try
            {
                // Full analysis
                AnalyzeResponse result = apiInstance.AnalyzeContextLanguagePost(context, language, analysisRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException e)
            {
                Debug.Print("Exception when calling DocumentAnalysisApi.AnalyzeContextLanguagePost: " + e.Message );
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
 **context** | **string**| Context name; use the &#x60;contexts&#x60; resource to discover available contexts | 
 **language** | **string**| Document language (code) | 
 **analysisRequest** | [**AnalysisRequest**](AnalysisRequest.md)| The document to be analyzed | [optional] 

### Return type

[**AnalyzeResponse**](AnalyzeResponse.md)

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


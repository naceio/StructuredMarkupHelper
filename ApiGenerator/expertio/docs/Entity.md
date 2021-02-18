
# ExpertIO.Client.Model.Entity

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** | Entity type | [optional] 
**Lemma** | **string** | Base form (lemma) of the entity name | [optional] 
**Syncon** | **long** | ID used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array | [optional] 
**Positions** | [**List&lt;DocumentPosition&gt;**](DocumentPosition.md) | Positions of the entity&#39;s mentions | [optional] 
**Relevance** | **long** | Entity relevance | [optional] 
**Attributes** | [**List&lt;InferredAttribute&gt;**](InferredAttribute.md) | Entity attributes inferred from the context or from the Knowledge Graph | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)


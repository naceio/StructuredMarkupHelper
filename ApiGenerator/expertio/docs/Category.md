
# ExpertIO.Client.Model.Category

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Category ID | [optional] 
**Label** | **string** | Category label | [optional] 
**Hierarchy** | **List&lt;string&gt;** | Hierarchical path | [optional] 
**Score** | **int** | Score assigned to the category to represent its relevance | [optional] 
**Winner** | **bool** | True if the category is deemed particularly relevant | [optional] 
**Namespace** | **string** | Name of the software package containing the reference taxonomy | [optional] 
**Frequency** | **float** | Score expressed as a percentage of the sum of the scores of all the candidate categories, winners and not (see the **score** property) | [optional] 
**Positions** | [**List&lt;DocumentPosition&gt;**](DocumentPosition.md) | Positions of the portions of text that contributed to the selection of the category | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)



# ExpertIO.Client.Model.Token

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Start** | **long** | Zero-based position of the first character of the token | [optional] 
**End** | **long** | Zero-based position of the first character after the token | [optional] 
**Type** | **string** | Cogito type | [optional] 
**Pos** | **string** | &lt;a href&#x3D;&#39;https://universaldependencies.org/u/pos/&#39;&gt;Universal Dependencies part-of-speech tag&lt;/a&gt; | [optional] 
**Lemma** | **string** | Lemma | [optional] 
**Syncon** | **long** | ID used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array | [optional] 
**Morphology** | **string** | A semicolon separated list of &lt;a href&#x3D;&#39;https://universaldependencies.org/format.html#morphological-annotation&#39;&gt;CoNLL-U format&lt;/a&gt; morphological features | [optional] 
**Dependency** | [**Dependency**](Dependency.md) |  | [optional] 
**Atoms** | [**List&lt;Atom&gt;**](Atom.md) | Atoms that make up the token | [optional] 
**Paragraph** | **long** | Paragraph index in the &#x60;paragraphs&#x60; array | [optional] 
**Sentence** | **long** | Sentence index in the &#x60;sentences&#x60; array | [optional] 
**Phrase** | **long** | Phrase index in the &#x60;phrases&#x60; array | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)


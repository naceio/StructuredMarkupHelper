/* 
 * expert.ai Natural Language API
 *
 * Natural Language API provides a comprehensive set of natural language understanding capabilities based on expert.ai technology: <ul>   <li>Text subdivision</li>   <li>Part-of-speech tagging</li>   <li>Syntactic analysis</li>   <li>Lemmatization</li>   <li>Keyphrase extraction</li>   <li>Semantic analysis</li>   <li>Named entity recognition</li>   <li>Relation extraction</li>   <li>Sentiment analysis</li>   <li>Classification</li> </ul> 
 *
 * The version of the OpenAPI document: v2
 * Contact: api.inquiry@expert.ai
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = ExpertIO.Client.Client.OpenAPIDateConverter;

namespace ExpertIO.Client.Model
{
    /// <summary>
    /// In a relation, a term that&#39;s directly or indirectly related to the verb
    /// </summary>
    [DataContract]
    public partial class RelatedItem :  IEquatable<RelatedItem>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelatedItem" /> class.
        /// </summary>
        /// <param name="relation">Verb-item relation.</param>
        /// <param name="text">Item text.</param>
        /// <param name="lemma">Lemma.</param>
        /// <param name="syncon">ID used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array.</param>
        /// <param name="vsyn">vsyn.</param>
        /// <param name="type">Type.</param>
        /// <param name="phrase">Phrase index in the &#x60;phrases&#x60; array.</param>
        /// <param name="relevance">Relevance.</param>
        /// <param name="related">Related terms.</param>
        public RelatedItem(string relation = default(string), string text = default(string), string lemma = default(string), long syncon = default(long), VirtualSyncon vsyn = default(VirtualSyncon), string type = default(string), long phrase = default(long), long relevance = default(long), List<RelatedItem> related = default(List<RelatedItem>))
        {
            this.Relation = relation;
            this.Text = text;
            this.Lemma = lemma;
            this.Syncon = syncon;
            this.Vsyn = vsyn;
            this.Type = type;
            this.Phrase = phrase;
            this.Relevance = relevance;
            this.Related = related;
        }
        
        /// <summary>
        /// Verb-item relation
        /// </summary>
        /// <value>Verb-item relation</value>
        [DataMember(Name="relation", EmitDefaultValue=false)]
        public string Relation { get; set; }

        /// <summary>
        /// Item text
        /// </summary>
        /// <value>Item text</value>
        [DataMember(Name="text", EmitDefaultValue=false)]
        public string Text { get; set; }

        /// <summary>
        /// Lemma
        /// </summary>
        /// <value>Lemma</value>
        [DataMember(Name="lemma", EmitDefaultValue=false)]
        public string Lemma { get; set; }

        /// <summary>
        /// ID used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array
        /// </summary>
        /// <value>ID used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array</value>
        [DataMember(Name="syncon", EmitDefaultValue=false)]
        public long Syncon { get; set; }

        /// <summary>
        /// Gets or Sets Vsyn
        /// </summary>
        [DataMember(Name="vsyn", EmitDefaultValue=false)]
        public VirtualSyncon Vsyn { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        /// <value>Type</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public string Type { get; set; }

        /// <summary>
        /// Phrase index in the &#x60;phrases&#x60; array
        /// </summary>
        /// <value>Phrase index in the &#x60;phrases&#x60; array</value>
        [DataMember(Name="phrase", EmitDefaultValue=false)]
        public long Phrase { get; set; }

        /// <summary>
        /// Relevance
        /// </summary>
        /// <value>Relevance</value>
        [DataMember(Name="relevance", EmitDefaultValue=false)]
        public long Relevance { get; set; }

        /// <summary>
        /// Related terms
        /// </summary>
        /// <value>Related terms</value>
        [DataMember(Name="related", EmitDefaultValue=false)]
        public List<RelatedItem> Related { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RelatedItem {\n");
            sb.Append("  Relation: ").Append(Relation).Append("\n");
            sb.Append("  Text: ").Append(Text).Append("\n");
            sb.Append("  Lemma: ").Append(Lemma).Append("\n");
            sb.Append("  Syncon: ").Append(Syncon).Append("\n");
            sb.Append("  Vsyn: ").Append(Vsyn).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Phrase: ").Append(Phrase).Append("\n");
            sb.Append("  Relevance: ").Append(Relevance).Append("\n");
            sb.Append("  Related: ").Append(Related).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as RelatedItem);
        }

        /// <summary>
        /// Returns true if RelatedItem instances are equal
        /// </summary>
        /// <param name="input">Instance of RelatedItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RelatedItem input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Relation == input.Relation ||
                    (this.Relation != null &&
                    this.Relation.Equals(input.Relation))
                ) && 
                (
                    this.Text == input.Text ||
                    (this.Text != null &&
                    this.Text.Equals(input.Text))
                ) && 
                (
                    this.Lemma == input.Lemma ||
                    (this.Lemma != null &&
                    this.Lemma.Equals(input.Lemma))
                ) && 
                (
                    this.Syncon == input.Syncon ||
                    (this.Syncon != null &&
                    this.Syncon.Equals(input.Syncon))
                ) && 
                (
                    this.Vsyn == input.Vsyn ||
                    (this.Vsyn != null &&
                    this.Vsyn.Equals(input.Vsyn))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Phrase == input.Phrase ||
                    (this.Phrase != null &&
                    this.Phrase.Equals(input.Phrase))
                ) && 
                (
                    this.Relevance == input.Relevance ||
                    (this.Relevance != null &&
                    this.Relevance.Equals(input.Relevance))
                ) && 
                (
                    this.Related == input.Related ||
                    this.Related != null &&
                    input.Related != null &&
                    this.Related.SequenceEqual(input.Related)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Relation != null)
                    hashCode = hashCode * 59 + this.Relation.GetHashCode();
                if (this.Text != null)
                    hashCode = hashCode * 59 + this.Text.GetHashCode();
                if (this.Lemma != null)
                    hashCode = hashCode * 59 + this.Lemma.GetHashCode();
                if (this.Syncon != null)
                    hashCode = hashCode * 59 + this.Syncon.GetHashCode();
                if (this.Vsyn != null)
                    hashCode = hashCode * 59 + this.Vsyn.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Phrase != null)
                    hashCode = hashCode * 59 + this.Phrase.GetHashCode();
                if (this.Relevance != null)
                    hashCode = hashCode * 59 + this.Relevance.GetHashCode();
                if (this.Related != null)
                    hashCode = hashCode * 59 + this.Related.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}

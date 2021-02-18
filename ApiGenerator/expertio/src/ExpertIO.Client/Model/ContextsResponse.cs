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
    /// Available contexts
    /// </summary>
    [DataContract]
    public partial class ContextsResponse :  IEquatable<ContextsResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextsResponse" /> class.
        /// </summary>
        /// <param name="contexts">List of contexts&#39; information.</param>
        public ContextsResponse(List<ContextInfo> contexts = default(List<ContextInfo>))
        {
            this.Contexts = contexts;
        }
        
        /// <summary>
        /// List of contexts&#39; information
        /// </summary>
        /// <value>List of contexts&#39; information</value>
        [DataMember(Name="contexts", EmitDefaultValue=false)]
        public List<ContextInfo> Contexts { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContextsResponse {\n");
            sb.Append("  Contexts: ").Append(Contexts).Append("\n");
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
            return this.Equals(input as ContextsResponse);
        }

        /// <summary>
        /// Returns true if ContextsResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of ContextsResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContextsResponse input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Contexts == input.Contexts ||
                    this.Contexts != null &&
                    input.Contexts != null &&
                    this.Contexts.SequenceEqual(input.Contexts)
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
                if (this.Contexts != null)
                    hashCode = hashCode * 59 + this.Contexts.GetHashCode();
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

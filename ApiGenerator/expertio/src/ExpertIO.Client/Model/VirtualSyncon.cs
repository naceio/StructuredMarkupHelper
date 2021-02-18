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
    /// A concept that does not exist in the Knowledge Graph but heuristics recognized as a type of a known parent concept.
    /// </summary>
    [DataContract]
    public partial class VirtualSyncon :  IEquatable<VirtualSyncon>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualSyncon" /> class.
        /// </summary>
        /// <param name="id">ID used to mark all the occurrences of the virtual concept in the text.</param>
        /// <param name="parent">Parent concept; ID is used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array.</param>
        public VirtualSyncon(long id = default(long), long parent = default(long))
        {
            this.Id = id;
            this.Parent = parent;
        }
        
        /// <summary>
        /// ID used to mark all the occurrences of the virtual concept in the text
        /// </summary>
        /// <value>ID used to mark all the occurrences of the virtual concept in the text</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public long Id { get; set; }

        /// <summary>
        /// Parent concept; ID is used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array
        /// </summary>
        /// <value>Parent concept; ID is used to look up Knowledge Graph data in the &#x60;knowledge&#x60; array</value>
        [DataMember(Name="parent", EmitDefaultValue=false)]
        public long Parent { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VirtualSyncon {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Parent: ").Append(Parent).Append("\n");
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
            return this.Equals(input as VirtualSyncon);
        }

        /// <summary>
        /// Returns true if VirtualSyncon instances are equal
        /// </summary>
        /// <param name="input">Instance of VirtualSyncon to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VirtualSyncon input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Parent == input.Parent ||
                    (this.Parent != null &&
                    this.Parent.Equals(input.Parent))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Parent != null)
                    hashCode = hashCode * 59 + this.Parent.GetHashCode();
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

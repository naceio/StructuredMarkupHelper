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
using System.Collections.Generic;

namespace ExpertIO.Client.Client
{
    /// <summary>
    /// API Response
    /// </summary>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Gets or sets the status code (HTTP status code)
        /// </summary>
        /// <value>The status code.</value>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets or sets the HTTP headers
        /// </summary>
        /// <value>HTTP headers</value>
        public IDictionary<string, string> Headers { get; private set; }

        /// <summary>
        /// Gets or sets the data (parsed HTTP body)
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse&lt;T&gt;" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        public ApiResponse(int statusCode, IDictionary<string, string> headers, T data)
        {
            this.StatusCode= statusCode;
            this.Headers = headers;
            this.Data = data;
        }

    }

}

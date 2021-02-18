using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StructuredMarkupHelper.Core.Models
{
    public class ApiResult<T>
    {
        public T Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public bool HasError { get; set; }
    }
}

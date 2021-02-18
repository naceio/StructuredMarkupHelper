using System;
using System.Collections.Generic;
using System.Text;

namespace StructuredMarkupHelper.Core.Models
{
    public class ExpertAiAuth
    {
        public string Token { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string TokenRequestEndpoint { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace StructuredMarkupHelper.Core.Models
{
    public class IptcSchemaOrgMap
    {
        public IptcVocab IptcVocab { get; set; }

        public SchemaOrgVocab SchemaOrgVocab { get; set; }

        public IptcSchemaOrgMap Clone()
        {
            return MemberwiseClone() as IptcSchemaOrgMap;
        }
    }
}

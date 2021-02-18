using System;
using System.Collections.Generic;
using System.Text;

namespace StructuredMarkupHelper.Core.Models
{
    public class TaxonomySchemaMap
    {
        public List<IptcVocab> IptcCategories { get; set; }

        public SchemaOrgVocab SchemaOrgType { get; set; }

        public List<MarkupDocumentPosition> Positions { get; set; }
    }

    public class MarkupDocumentPosition
    {
        public int Start { get; set; }

        public int End { get; set; }
    }
}

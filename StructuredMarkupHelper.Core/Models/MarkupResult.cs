using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StructuredMarkupHelper.Core.Models
{
    public class MarkupResult
    {
        public MarkupDocument Document { get; set; }

        public List<TaxonomySchemaMap> Mappings { get; set; }

        //public JArray Tokens
        //{
        //    get
        //    {
        //        JArray array = new JArray();

        //        foreach (var m in Mappings)
        //        {
        //            foreach (var p in m.Positions)
        //            {
        //                JObject token = new JObject();
        //                token.Add("schema", m.SchemaOrgType.SchemaType);
        //                token.Add("iptc", string.Join("#", m.IptcCategories.Select(x => x.IptcLabel)));
        //                token.Add("token", Document.Text.Substring(p.Start, p.End - p.Start));
        //                array.Add(token);
        //            }
        //        }

        //        return array;
        //    }
        //}
    }
}

using FuzzySharp;
using Newtonsoft.Json.Linq;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructuredMarkupHelper.Core.Infrastructure
{
    public class SchemaVocabMappingGenerator
    {
        public List<IptcSchemaOrgMap> GenerateMappings(JObject taxonomies, JArray schemaGraph)
        {
            var mappings = new List<IptcSchemaOrgMap>();

            BuildMappings(taxonomies, schemaGraph, mappings);

            return mappings;
        }

        private void BuildMappings(JObject taxonomy, JArray schemaGraph, List<IptcSchemaOrgMap> mappings)
        {
            IptcSchemaOrgMap mapItem = new IptcSchemaOrgMap
            {
                IptcVocab = new IptcVocab
                {
                    IptcId = taxonomy.Value<string>("id"),
                    IptcLabel = taxonomy.Value<string>("label")
                }
            };

            var children = taxonomy.GetValue("categories") as JArray;
            if (children != null)
            {
                foreach (JObject c in children)
                {
                    BuildMappings(c, schemaGraph, mappings);
                }
            }

            foreach (JObject schema in schemaGraph)
            {
                var schemaType = schema.GetValue("@type");
                if (schemaType.Type == JTokenType.Array)
                {
                    if ((schemaType as JArray).Any(x => x.Value<string>() == "rdfs:Class") == false)
                    {
                        continue;
                    }
                }
                else if (schemaType.Value<string>() != "rdfs:Class")
                {
                    continue;
                }

                var item = mapItem.Clone();
                item.SchemaOrgVocab = new SchemaOrgVocab();
                item.SchemaOrgVocab.SchemaId = schema.Value<string>("@id");
                item.SchemaOrgVocab.SchemaType = item.SchemaOrgVocab.SchemaId.Replace("schema:", string.Empty);

                var score = Fuzz.PartialRatio(item.IptcVocab.IptcLabel, item.SchemaOrgVocab.SchemaType);

                if (score > 80)
                {
                    mappings.Add(item);
                }
            }
        }
    }
}

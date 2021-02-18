using Newtonsoft.Json.Linq;
using StructuredMarkupHelper.Core.Infrastructure;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StructuredMarkupHelper.Core
{
    public class MarkupService
    {
        ExpertAiAuth expertAiAuth;
        List<IptcSchemaOrgMap> iptcSchemaOrgMap;

        private ApiResult<T> WrapResult<T>(Func<T> func)
        {
            try
            {
                return new ApiResult<T>
                {
                    Data = func(),
                    HasError = false
                };
            }
            catch (Exception e)
            {
                return new ApiResult<T>
                {
                    HasError = true,
                    Message = e.Message
                };
            }
        }

        public void SetIptcSchemaOrgMap(List<IptcSchemaOrgMap> iptcSchemaOrgMap)
        {
            this.iptcSchemaOrgMap = iptcSchemaOrgMap;
        }

        public void SetExpertAiAuthentication(ExpertAiAuth auth)
        {
            expertAiAuth = auth;
        }

        public ApiResult<MarkupResult> FindMappings(MarkupDocument doc)
        {
            return WrapResult(() =>
            {
                var taxonomySchemaMapper = new TaxonomySchemaMapper();
                taxonomySchemaMapper.SetExpertAiAuthentication(expertAiAuth);
                taxonomySchemaMapper.SetIptcSchemaOrgMap(iptcSchemaOrgMap);
                return taxonomySchemaMapper.FindMappings(doc);
            });
        }

        public ApiResult<List<IptcSchemaOrgMap>> GenerateMappings(JObject taxonomies, JArray schemaGraph)
        {
            return WrapResult(() =>
            {
                var mappingGenerator = new SchemaVocabMappingGenerator();
                return mappingGenerator.GenerateMappings(taxonomies, schemaGraph);
            });
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StructuredMarkupHelper.Infrastructure
{
    public class MarkupContext
    {
        private static object mapLock = new object();
        private static List<IptcSchemaOrgMap> vocabMappings;

        IConfiguration configuration;

        public MarkupContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<IptcSchemaOrgMap> VocabMappings
        {
            get
            {
                if (vocabMappings != null)
                {
                    return vocabMappings;
                }

                lock (mapLock)
                {
                    if (vocabMappings != null)
                    {
                        return vocabMappings;
                    }

                    var path = GetConfig<string>("IPTC_SCHEMA_MAP");

                    var jArray = JArray.Parse(File.ReadAllText(path));

                    vocabMappings = jArray.ToObject<List<IptcSchemaOrgMap>>();

                    return vocabMappings;
                }
            }
        }

        public T GetConfig<T>(string configPath, string envVariable = null)
        {
            envVariable = envVariable ?? $"MARKUP_GEN_{configPath}";

            T value = default(T);

            var envValue = Environment.GetEnvironmentVariable(envVariable);

            if (envValue != null)
            {
                value = (T)Convert.ChangeType(envValue, typeof(T));
            }
            else
            {
                value = configuration.GetValue<T>(configPath);
            }

            return value;
        }
    }
}

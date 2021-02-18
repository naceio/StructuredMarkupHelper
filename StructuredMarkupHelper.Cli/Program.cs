using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StructuredMarkupHelper.Core;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;

namespace StructuredMarkupHelper.Cli
{
    class Program
    {
        /// <summary>
        /// 
        /// To generate vocab mapping:
        /// --generate-vocab-mapping --base-path ../../../wdir --schema schemaorg-current-http.json --iptc-vocab taxonomies.json --vocab-output iptc_schemaorg_map.json
        ///
        /// 
        /// To generate markup:
        /// --generate-markup --base-path ../../../wdir --document document.txt --vocab-mapping iptc_schemaorg_map_truncated.json --expertai-config expertai-config.json --markup-output markup-mapping.json
        /// 
        /// </summary>
        static int Main(string[] args)
        {
            var rootCommand = new RootCommand
            {
                new Option<string>(
                        "--base-path",
                        description: "Working directory"
                    ),

                new Option<bool>(
                        "--generate-markup",
                        getDefaultValue: () => false,
                        description: "Generate markup"
                    ),
                 new Option<string>(
                        "--document",
                        "Document path"
                    ),
                 new Option<string>(
                        "--vocab-mapping",
                        "Vocab mapping path"
                    ),
                 new Option<string>(
                        "--expertai-config",
                        "Expert.ai config path"
                    ),
                new Option<string>(
                        "--markup-output",
                        "Markup mapping output"
                    ),

                new Option<bool>(
                        "--generate-vocab-mapping",
                        getDefaultValue: () => false,
                        description: "Generate Iptc and SchemaOrg vocab mapping"
                    ),
                new Option<string>(
                        "--schema",
                        "Schema.org path"
                    ),
                new Option<string>(
                        "--iptc-vocab",
                        "IPTC vocab path"
                    ),
                new Option<string>(
                        "--vocab-output",
                        "Vocab mapping output"
                    ),
            };

            rootCommand.Description = "Structured Markup Helper Cli";

            var parsedResult = rootCommand.Parse(args);

            string basePath = parsedResult.ValueForOption<string>("--base-path");

            if (parsedResult.ValueForOption<bool>("--generate-markup"))
            {
                string documentPath = parsedResult.ValueForOption<string>("--document");
                string vocabMappingPath = parsedResult.ValueForOption<string>("--vocab-mapping");
                string expertaiConfigPath = parsedResult.ValueForOption<string>("--expertai-config");
                string ouputPath = parsedResult.ValueForOption<string>("--markup-output") ?? "markup-mapping.json";

                if (string.IsNullOrEmpty(documentPath))
                {
                    rootCommand.AddValidator(_ => "Use --document option to pass the document");
                }
                if (string.IsNullOrEmpty(vocabMappingPath))
                {
                    rootCommand.AddValidator(_ => "Use --vocab-mapping option to pass extracted mappings");
                }
                else if (string.IsNullOrEmpty(expertaiConfigPath))
                {
                    rootCommand.AddValidator(_ => "Use --expertai-config option to pass Expert.ai config");
                }
                else
                {
                    documentPath = FindPath(basePath, documentPath);
                    vocabMappingPath = FindPath(basePath, vocabMappingPath);
                    expertaiConfigPath = FindPath(basePath, expertaiConfigPath);
                    ouputPath = FindPath(basePath, ouputPath);

                    Console.WriteLine($"Generating markup...");
                    var result = GenerateMarkup(documentPath, vocabMappingPath, expertaiConfigPath, ouputPath);

                    if (result.HasError)
                    {
                        Console.WriteLine(result.Message);
                    }
                    else
                    {
                        File.WriteAllText(ouputPath, JsonConvert.SerializeObject(result.Data, Formatting.Indented));
                        Console.WriteLine($"Markup generated at {ouputPath}");
                    }
                }
            }

            if (parsedResult.ValueForOption<bool>("--generate-vocab-mapping"))
            {
                string taxonomyPath = parsedResult.ValueForOption<string>("--iptc-vocab");
                string schemaPath = parsedResult.ValueForOption<string>("--schema");
                string ouputPath = parsedResult.ValueForOption<string>("--vocab-output") ?? "iptc_schemaorg_map.json";

                if (string.IsNullOrEmpty(taxonomyPath))
                {
                    rootCommand.AddValidator(_ => "Use --iptc-vocab option to pass taxonomies");
                }
                else if (string.IsNullOrEmpty(schemaPath))
                {
                    rootCommand.AddValidator(_ => "Use --schema option to pass schemas");
                }
                else
                {
                    taxonomyPath = FindPath(basePath, taxonomyPath);
                    schemaPath = FindPath(basePath, schemaPath);
                    ouputPath = FindPath(basePath, ouputPath);

                    Console.WriteLine($"Generating vocab...");
                    var result = GenerateVocabMapping(taxonomyPath, schemaPath, ouputPath);

                    if (result.HasError)
                    {
                        Console.WriteLine(result.Message);
                    }
                    else
                    {
                        File.WriteAllText(ouputPath, JsonConvert.SerializeObject(result.Data, Formatting.Indented));
                        Console.WriteLine($"Vocab generated at {ouputPath}");
                    }
                }
            }

            return rootCommand.InvokeAsync(args).Result;
        }

        private static ApiResult<List<IptcSchemaOrgMap>> GenerateVocabMapping(string taxonomyPath, string schemaPath, string ouputPath)
        {
            var markupService = new MarkupService();

            JObject iptc = JObject.Parse(File.ReadAllText(taxonomyPath));
            JObject schemaOrg = JObject.Parse(File.ReadAllText(schemaPath));

            var mappingsResult = markupService.GenerateMappings(iptc.SelectToken("$.data[0].taxonomy[0]") as JObject, schemaOrg.GetValue("@graph") as JArray);

            return mappingsResult;
        }

        private static ApiResult<MarkupResult> GenerateMarkup(string documentPath, string vocabMappingPath, string expertaiConfigPath, string ouputPath)
        {
            var markupService = new MarkupService();

            string documentContent = File.ReadAllText(documentPath);
            JArray vocabMapping = JArray.Parse(File.ReadAllText(vocabMappingPath));
            JObject expertaiConfig = JObject.Parse(File.ReadAllText(expertaiConfigPath));

            markupService.SetIptcSchemaOrgMap(vocabMapping.ToObject<List<IptcSchemaOrgMap>>());
            markupService.SetExpertAiAuthentication(expertaiConfig.ToObject<ExpertAiAuth>());
            var markupResult = markupService.FindMappings(new MarkupDocument
            {
                Text = documentContent
            });

            return markupResult;
        }

        private static string FindPath(string basePath, string path)
        {
            if (string.IsNullOrEmpty(basePath))
            {
                return Path.GetFullPath(path);
            }


            return Path.Combine(Path.GetFullPath(basePath), path);
        }
    }
}

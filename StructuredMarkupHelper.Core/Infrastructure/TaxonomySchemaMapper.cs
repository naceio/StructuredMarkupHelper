using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StructuredMarkupHelper.Core.Infrastructure
{
    public class TaxonomySchemaMapper
    {
        private static ConcurrentDictionary<string, MarkupResult> cachedResult = new ConcurrentDictionary<string, MarkupResult>();

        ExpertAiAuth expertAiAuth;
        List<IptcSchemaOrgMap> iptcSchemaOrgMap;

        public void SetIptcSchemaOrgMap(List<IptcSchemaOrgMap> iptcSchemaOrgMap)
        {
            this.iptcSchemaOrgMap = iptcSchemaOrgMap;
        }

        public void SetExpertAiAuthentication(ExpertAiAuth auth)
        {
            expertAiAuth = auth;
        }

        public string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public MarkupResult FindMappings(MarkupDocument doc)
        {
            string sanitizedText = SanitizeText(doc.Text);

            string cacheId = CreateMD5(sanitizedText);

            if (cachedResult.TryGetValue(cacheId, out MarkupResult markupResult) == false)
            {
                markupResult = new MarkupResult
                {
                    Document = new MarkupDocument
                    {
                        Text = sanitizedText
                    }
                };

                if (iptcSchemaOrgMap == null)
                {
                    throw new InvalidOperationException($"Please provide Schema.org and Iptc vocab mapping");
                }

                ExpertAiService expertAiService = new ExpertAiService();
                expertAiService.SetAuthentication(expertAiAuth);

                Dictionary<string, TaxonomySchemaMap> parsedMaps = new Dictionary<string, TaxonomySchemaMap>();

                var splittedDoc = DocumentSplitter(sanitizedText);

                //if (splittedDoc.Count > 10)
                //{
                //    throw new InvalidOperationException($"Content is too large");
                //}

                if (splittedDoc.Count > 10)
                {
                    splittedDoc = splittedDoc.Take(10).ToList();
                }

                foreach (var sDoc in splittedDoc)
                {
                    var iptcResult = expertAiService.IptcCategorize(new AnalysisRequest
                    {
                        Document = new Document
                        {
                            Text = sDoc.Text
                        }
                    });

                    foreach (var category in iptcResult.Data.Categories)
                    {
                        var foundedMaps = iptcSchemaOrgMap.Where(x => x.IptcVocab.IptcId == category.Id).ToList();

                        if (foundedMaps.Count == 0)
                        {
                            continue;
                        }

                        foreach (var m in foundedMaps)
                        {
                            if (parsedMaps.TryGetValue(m.SchemaOrgVocab.SchemaId, out TaxonomySchemaMap resultMap) == false)
                            {
                                resultMap = new TaxonomySchemaMap
                                {
                                    SchemaOrgType = m.SchemaOrgVocab,
                                    IptcCategories = new List<IptcVocab>(),
                                    Positions = new List<MarkupDocumentPosition>()
                                };

                                parsedMaps.Add(m.SchemaOrgVocab.SchemaId, resultMap);
                            }

                            if (resultMap.IptcCategories.Any(x => x.IptcId == m.IptcVocab.IptcId) == false)
                            {
                                resultMap.IptcCategories.Add(m.IptcVocab);
                            }

                            category.Positions.ForEach(x =>
                            {
                                var tokenPos = new MarkupDocumentPosition
                                {
                                    Start = Convert.ToInt32(sDoc.Start + x.Start),
                                    End = Convert.ToInt32(sDoc.Start + x.End)
                                };

                                var tokenText = markupResult.Document.Text.Substring(tokenPos.Start, tokenPos.End - tokenPos.Start);

                                resultMap.Positions.Add(tokenPos);
                            });


                        }
                    }
                }

                markupResult.Mappings = parsedMaps.Values.ToList();

                cachedResult.TryAdd(cacheId, markupResult);
            }

            return markupResult;
        }

        private List<MarkupDocument> DocumentSplitter(string document)
        {
            List<MarkupDocument> result = new List<MarkupDocument>();

            int limitIndex = 0;
            int startIndex = 0;
            bool startFindingDot = false;
            var sb = new StringBuilder();
            for (int i = 0; i < document.Length; i++)
            {
                sb.Append(document[i]);

                //if (limitIndex == 3750)
                if (limitIndex == 200)
                {
                    startFindingDot = true;
                }

                if ((startFindingDot && document[i] == '.') || limitIndex == 4300)
                {
                    result.Add(new MarkupDocument
                    {
                        Text = sb.ToString(),
                        Start = startIndex
                    });
                    startIndex = i + 1;
                    startFindingDot = false;
                    limitIndex = 0;
                    sb = new StringBuilder();
                }

                limitIndex++;
            }

            if (result.Count == 0)
            {
                result.Add(new MarkupDocument
                {
                    Text = sb.ToString()
                });
            }

            return result;
        }

        private string SanitizeText(string text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if ((c >= '0' && c <= '9') ||
                    (c >= 'A' && c <= 'Z') ||
                    (c >= 'a' && c <= 'z') ||
                    new char[] { ' ', '.', ',', ';', ':' }.Contains(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Trim();
        }
    }
}

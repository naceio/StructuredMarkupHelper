using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StructuredMarkupHelper.Core;
using StructuredMarkupHelper.Core.Infrastructure;
using StructuredMarkupHelper.Core.Models;
using StructuredMarkupHelper.Infrastructure;
using StructuredMarkupHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StructuredMarkupHelper.Controllers
{
    [Route("markup")]
    [ApiController]
    public class MarkupController : ControllerBase
    {
        MarkupContext markupContext;

        public MarkupController(MarkupContext markupContext)
        {
            this.markupContext = markupContext;
        }

        [HttpGet]
        [Route("index")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ContentResult Index()
        {
            return Content("Hello raoof", "text/html");
        }

        [HttpGet]
        [Route("webpage")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ContentResult WebPage(string url)
        {
            HeadlessBrowser headlessBrowser = new HeadlessBrowser();
            var html = headlessBrowser.GetHtmlText(
                    markupContext.GetConfig<string>("PHANTOM_API"),
                    url
                );

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            return Content(htmlDoc.DocumentNode.InnerHtml, "text/html");
        }

        [HttpPost]
        [Route("text-markup")]
        public ApiResult<MarkupResult> TextMarkup([FromBody] MarkupDocument request)
        {
            return GenerateMarkup(request);
        }

        [HttpPost]
        [Route("url-markup")]
        public ApiResult<MarkupResult> UrlMarkup([FromBody] HtmlMarkupRequest request)
        {
            HeadlessBrowser headlessBrowser = new HeadlessBrowser();
            var html = headlessBrowser.GetHtmlText(
                    markupContext.GetConfig<string>("PHANTOM_API"),
                    request.Url
                );

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var content = headlessBrowser.GetContent(htmlDoc);

            return GenerateMarkup(new MarkupDocument
            {
                Text = content
            });
        }

        private ApiResult<MarkupResult> GenerateMarkup(MarkupDocument request)
        {
            var markupService = new MarkupService();

            var expertAiConfig = new ExpertAiAuth
            {
                Username = markupContext.GetConfig<string>("EXPERTAI_USERNAME"),
                Password = markupContext.GetConfig<string>("EXPERTAI_PASSWORD"),
                TokenRequestEndpoint = markupContext.GetConfig<string>("EXPERTAI_TOKEN_ENDPOINT")
            };

            markupService.SetIptcSchemaOrgMap(markupContext.VocabMappings);
            markupService.SetExpertAiAuthentication(expertAiConfig);
            var markupResult = markupService.FindMappings(request);

            return markupResult;
        }
    }
}

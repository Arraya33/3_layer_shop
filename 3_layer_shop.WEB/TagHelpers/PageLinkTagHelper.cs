using _3_layer_shop.WEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_layer_shop.WEB.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("ul");
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder item = new TagBuilder("li");
                if (i == PageModel.CurrentPage)
                {
                    item.AddCssClass("active");
                    item.InnerHtml.Append(i.ToString() + ".");
                }
                else
                {
                    TagBuilder link = new TagBuilder("a");

                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("page", i.ToString());

                    if (PageModel.Parameters != null)
                    {
                        parameters = parameters.Union(PageModel.Parameters).ToDictionary(p => p.Key, p => p.Value);
                    }


                    link.Attributes["href"] = urlHelper.Action(PageModel.PageAction, parameters);
                    link.InnerHtml.Append(i.ToString() + ".");
                    item.InnerHtml.AppendHtml(link);
                }
                result.InnerHtml.AppendHtml(item);
            }
            output.Content.AppendHtml(result);
        }
    }
}

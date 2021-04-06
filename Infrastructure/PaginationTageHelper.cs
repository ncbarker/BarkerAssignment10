using BarkerAssignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarkerAssignment10.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]

    public class PaginationTageHelper : TagHelper 
    {
        private IUrlHelperFactory urlInfo { get; set; }
        public PaginationTageHelper(IUrlHelperFactory uhf)
        {
            urlInfo = uhf;
        }

        public PageNumberingInfo PageInfo { get; set; }

        public bool SetUpCorrectly { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder finishedTag = new TagBuilder("div");
            TagBuilder individualTag = new TagBuilder("a");

            for (int i= 1; i < PageInfo.NumPages; i++)
            {
                individualTag.Attributes["href"] = "/?pagenum=" + i;
                individualTag.InnerHtml.AppendHtml(i.ToString());

                finishedTag.InnerHtml.AppendHtml(individualTag);

            }

            

            output.Content.AppendHtml(finishedTag);
        }

    }
}

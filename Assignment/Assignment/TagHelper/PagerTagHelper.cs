using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPagingAndCart.Tags
{
    [HtmlTargetElement("pager")]
    public class PagerTagHelper: TagHelper
    {
        public int TotalPage { get; set; }
        public string Url { get; set; }
        public int CurrentPage { get; set; }
        public string ActiveClass { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            if (TotalPage <= 1) return;
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "something");
            for (int i = 1; i <= TotalPage; i++)
                if (i == CurrentPage)                    
                    output.Content.AppendHtml($"<a style='margin:4px;' class='{ActiveClass}' href='{Url}/{i}'>{i}</a>");
                else
                    output.Content.AppendHtml($"<a style='margin:4px;' href={Url}/{i}>{i}</a>");
        }
    }
}

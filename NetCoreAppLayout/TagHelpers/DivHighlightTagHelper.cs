using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.TagHelpers
{
    //div elementine gönderilerün renge göre div elementini değiştiriyoruz
    [HtmlTargetElement("div", Attributes ="color")]
    public class DivHighlightTagHelper:TagHelper
    {
        public string Color { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class",$"text-{Color}");                
            base.Process(context, output);
        }
    }
}

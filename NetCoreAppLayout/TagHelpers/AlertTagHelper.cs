using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAppLayout.TagHelpers
{//içerisine gönderilecek verinin çekilmiş olması lazım db den yapılmaz çekilmiş veriye yapılır.
    public static class BsColorClass{
        public const string Success = "success";
        public const string Danger = "danger";
        public const string Info = "ınfo";
        public const string Warning = "warning";
    }
    public static class BSElementType
    {
        public const string Alert = "alert";
        public const string Button = "btn";
    }
    [HtmlTargetElement("bs-alert", Attributes="message, color")]
    public class AlertTagHelper:TagHelper
    {
        public string Message { get; set; }//attributeden gelen değerler propertiye bağlanır
        public string Color { get; set; }
        //tag heelper ı viewdeen çağırdığımızd tetiklenen metod
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";//çıktıyı div yap 
            output.Attributes.Add("class", $"{BSElementType.Alert} {BSElementType.Alert}-{Color}");
            output.Attributes.Add("role", BSElementType.Alert);
            output.Content.SetContent(Message);

            base.Process(context, output);
        }
    }
}

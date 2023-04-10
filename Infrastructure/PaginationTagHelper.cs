using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WhosYourMummy.Infrastructure
{
    /*// This tag helper will target div elements with a "page-model" attribute
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper
    {
        // Dependency injection is used to get an IUrlHelperFactory instance
        private IUrlHelperFactory uhf;

        // Constructor that takes an IUrlHelperFactory instance
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        // This property will be set by the Razor engine and contains information about the current view
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        // This property will be set by the Razor engine and contains information about the pagination
        public PageInfo PageModel { get; set; }

        // This property will be set by the Razor engine and contains the name of the action method for generating links
        public string PageAction { get; set; }

        // These properties control the CSS classes that will be applied to the pagination links
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        // This method generates the HTML for the pagination links
        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            // Get an instance of IUrlHelper from the IUrlHelperFactory
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            // Create a new div tag that will contain the pagination links
            TagBuilder final = new TagBuilder("div");

            // Add a pagination link for each page
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                // Create an anchor tag for the current page
                TagBuilder tb = new TagBuilder("a");
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                // Add CSS classes to the anchor tag if enabled
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                // Set the text of the anchor tag to the current page number
                tb.InnerHtml.Append(i.ToString());

                // Add the anchor tag to the div tag
                final.InnerHtml.AppendHtml(tb);
            }

            // Add the div tag to the TagHelperOutput
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }*/
}


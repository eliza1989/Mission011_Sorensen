using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission011_Sorensen.Models.ViewModels;

namespace Mission011_Sorensen.Infrastructure
{
    //Create div for page-model
    [HtmlTargetElement("div", Attributes = "page-model")]

    //Create  Pagination Tag Helper Class that Inherits from Tag Helper
    public class PaginationTagHelper : TagHelper
    {

        //Create a private instance of urlHelperFactory
        private IUrlHelperFactory urlHelperFactory;


        //Create a temporary instance of the urlFactory Helper
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }


        //Specify the following as View Context and Non-bound
        [ViewContext]
        [HtmlAttributeNotBound]

        //Create The different elements to allow functionality between pages and page buttons
        public ViewContext? ViewContext { get; set; }

        public string? PageAction { get; set; }

        public PaginationInfo PageModel { get; set; }

        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; } = String.Empty;

        public string PageClassNormal { get; set; } = String.Empty;

        public string PageClassSelected { get; set; } = String.Empty;


        //Create the function that will create a tags and div tags that will dynamically create the button for each page along with the Css
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(ViewContext != null && PageModel != null) {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i=1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}

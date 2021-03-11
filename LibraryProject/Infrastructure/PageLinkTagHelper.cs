﻿using LibraryProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Infrastructure
{
    //This page helps create tag helpers that build dynamic HTML pages
    //Bc it says "div" right here, all these things can be added to div tag
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        //Constructor for PageLinkTagHelpexr
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //Goes to Models.Viewmodels to get this
        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        //Grab the part after url- from the tag, put it into dictionary ex. category, category object
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        //things 
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Overriding method = replace it with our own information
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            //Creates links at bottom of page
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");


                PageUrlValues["page"] = i;

                //PageAction says we go to Index, Parameters we will send are from the PageUrlValues ex. category: object
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
                

                if(PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                
                tag.InnerHtml.Append(i.ToString());
                
                result.InnerHtml.AppendHtml(tag);
            }

            //all these url's are appended to result which is handed to website so it can quickly look pages up
            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}

#pragma checksum "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997a76ccf1302c4c11e87e869f51a94eda63d524"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_Details), @"mvc.1.0.view", @"/Views/Projects/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Projects/Details.cshtml", typeof(AspNetCore.Views_Projects_Details))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#line 2 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"997a76ccf1302c4c11e87e869f51a94eda63d524", @"/Views/Projects/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Application.DataTransfer.ProjectDto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(89, 30, true);
            WriteLiteral("\r\n<h2>Project Details</h2>\r\n\r\n");
            EndContext();
#line 9 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
 if (Model == null)
{

#line default
#line hidden
            BeginContext(143, 33, true);
            WriteLiteral("    <h1>Project Not Exists</h1>\r\n");
            EndContext();
#line 12 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(188, 126, true);
            WriteLiteral("    <div>\r\n        <h4>ProjectDto</h4>\r\n        <hr />\r\n        <dl class=\"dl-horizontal\">\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(315, 38, false);
#line 20 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(353, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(409, 34, false);
#line 23 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(443, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(499, 41, false);
#line 26 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(540, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(596, 37, false);
#line 29 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(633, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(689, 47, false);
#line 32 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(736, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(792, 43, false);
#line 35 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(835, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(891, 45, false);
#line 38 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(936, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(992, 41, false);
#line 41 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(1089, 43, false);
#line 44 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1132, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1188, 39, false);
#line 47 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1227, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(1283, 44, false);
#line 50 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(1327, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1383, 40, false);
#line 53 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(1423, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(1479, 47, false);
#line 56 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.StatusValue));

#line default
#line hidden
            EndContext();
            BeginContext(1526, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(1582, 43, false);
#line 59 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
           Write(Html.DisplayFor(model => model.StatusValue));

#line default
#line hidden
            EndContext();
            BeginContext(1625, 48, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n");
            EndContext();
#line 63 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
}

#line default
#line hidden
            BeginContext(1676, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(1688, 54, false);
#line 65 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1742, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1750, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc36a8872fdf43d09a1fbe076bba4445", async() => {
                BeginContext(1772, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1788, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Application.DataTransfer.ProjectDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
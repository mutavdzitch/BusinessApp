#pragma checksum "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc5e9c36d013c1c6b9e9a65fbba2008f48022844"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Projects_Index), @"mvc.1.0.view", @"/Views/Projects/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Projects/Index.cshtml", typeof(AspNetCore.Views_Projects_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc5e9c36d013c1c6b9e9a65fbba2008f48022844", @"/Views/Projects/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Projects_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Application.DataTransfer.ProjectDto>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(100, 32, true);
            WriteLiteral("\r\n<h2>Projects</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(132, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fbd78833a49a466282119ad3f5321de9", async() => {
                BeginContext(155, 10, true);
                WriteLiteral("Create New");
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
            BeginContext(169, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(262, 38, false);
#line 16 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(300, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(356, 41, false);
#line 19 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(397, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(453, 47, false);
#line 22 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
            EndContext();
            BeginContext(500, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(556, 45, false);
#line 25 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(601, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(657, 43, false);
#line 28 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(700, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(756, 44, false);
#line 31 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(800, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(856, 47, false);
#line 34 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StatusValue));

#line default
#line hidden
            EndContext();
            BeginContext(903, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1021, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1070, 37, false);
#line 43 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1107, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1163, 40, false);
#line 46 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1203, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1259, 46, false);
#line 49 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1305, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1361, 44, false);
#line 52 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StartDate));

#line default
#line hidden
            EndContext();
            BeginContext(1405, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1461, 42, false);
#line 55 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.EndDate));

#line default
#line hidden
            EndContext();
            BeginContext(1503, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1559, 43, false);
#line 58 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StatusId));

#line default
#line hidden
            EndContext();
            BeginContext(1602, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1658, 46, false);
#line 61 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.StatusValue));

#line default
#line hidden
            EndContext();
            BeginContext(1704, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1760, 51, false);
#line 64 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1811, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1832, 57, false);
#line 65 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1889, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1910, 55, false);
#line 66 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(1965, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 69 "D:\ICT\ASP.NET\Project\MarkoMutavdzic12516\WebApp\Views\Projects\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2004, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Application.DataTransfer.ProjectDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591

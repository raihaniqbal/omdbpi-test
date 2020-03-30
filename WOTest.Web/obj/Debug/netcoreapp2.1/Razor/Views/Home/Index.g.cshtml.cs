#pragma checksum "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d3a390d6df37797a902e296987da68b2340fb4b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\_ViewImports.cshtml"
using WOTest.Web;

#line default
#line hidden
#line 2 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\_ViewImports.cshtml"
using WOTest.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d3a390d6df37797a902e296987da68b2340fb4b5", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2cb00921ae76d46313626ff6c950df6ac0746d63", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Movie Search";

#line default
#line hidden
            DefineSection("JSONLdScripts", async() => {
                BeginContext(93, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 7 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
     if (Model != null)
    {

#line default
#line hidden
                BeginContext(127, 59, true);
                WriteLiteral("        <script type=\"application/ld+json\">\r\n\r\n            ");
                EndContext();
                BeginContext(187, 28, false);
#line 11 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
       Write(Html.Raw(Model.JsonLdSchema));

#line default
#line hidden
                EndContext();
                BeginContext(215, 23, true);
                WriteLiteral("\r\n\r\n        </script>\r\n");
                EndContext();
#line 14 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            }
            );
            BeginContext(248, 86, true);
            WriteLiteral("<div class=\"row\">\r\n    <h1>OMDB Movie Search</h1>\r\n</div>\r\n<hr />\r\n<div class=\"row\">\r\n");
            EndContext();
#line 21 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
     using (Html.BeginForm("Search", "Home", FormMethod.Get, new { @class = "form-inline" }))
    {

#line default
#line hidden
            BeginContext(436, 46, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(483, 41, false);
#line 24 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
       Write(Html.LabelFor(l => l.SearchText, "Title"));

#line default
#line hidden
            EndContext();
            BeginContext(524, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(539, 67, false);
#line 25 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
       Write(Html.TextBoxFor(t => t.SearchText, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(606, 89, true);
            WriteLiteral("\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Search</button>\r\n");
            EndContext();
#line 28 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(702, 35, true);
            WriteLiteral("</div>\r\n<hr />\r\n<div class=\"row\">\r\n");
            EndContext();
#line 32 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
     if (Model != null && Model.SearchResults != null)
    {

#line default
#line hidden
            BeginContext(800, 520, true);
            WriteLiteral(@"        <div class=""panel panel-default"">
            <div class=""panel-heading"">Search Results</div>
            <div class=""panel-body"">
                <table class=""table table-striped"">
                    <thead>
                        <tr>
                            <td>Title</td>
                            <td>Year</td>
                            <td>IMDB ID</td>
                            <td>Type</td>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 47 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                         foreach (var result in Model.SearchResults)
                        {

#line default
#line hidden
            BeginContext(1417, 108, true);
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1526, 78, false);
#line 51 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                               Write(Html.ActionLink(result.Title, "MovieDetails", new { imdbId =  result.ImdbId }));

#line default
#line hidden
            EndContext();
            BeginContext(1604, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1720, 11, false);
#line 54 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                               Write(result.Year);

#line default
#line hidden
            EndContext();
            BeginContext(1731, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1847, 13, false);
#line 57 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                               Write(result.ImdbId);

#line default
#line hidden
            EndContext();
            BeginContext(1860, 115, true);
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            EndContext();
            BeginContext(1976, 11, false);
#line 60 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                               Write(result.Type);

#line default
#line hidden
            EndContext();
            BeginContext(1987, 76, true);
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 63 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2090, 92, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 68 "D:\My Stuff\Projects\omdbpi-test\WOTest.Web\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(2189, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

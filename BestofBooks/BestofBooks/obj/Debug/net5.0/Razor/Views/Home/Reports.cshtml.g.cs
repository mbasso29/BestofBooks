#pragma checksum "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/Home/Reports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "693bd76dae40553204425c50884156c32c754cee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Reports), @"mvc.1.0.view", @"/Views/Home/Reports.cshtml")]
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
#nullable restore
#line 1 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/_ViewImports.cshtml"
using BestofBooks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/_ViewImports.cshtml"
using BestofBooks.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"693bd76dae40553204425c50884156c32c754cee", @"/Views/Home/Reports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb778e8b252ce8212c8babbb90ac19c3aee39392", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Reports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/Home/Reports.cshtml"
  
    ViewData["Title"] = "Reports";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/Home/Reports.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n<p>Testing Reports.</p>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
#nullable restore
#line 10 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/Home/Reports.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n    ");
#nullable restore
#line 11 "/Users/dereklewis/Documents/GitHub/BestofBooks/BestofBooks/BestofBooks/Views/Home/Reports.cshtml"
Write(await Html.PartialAsync("Login"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

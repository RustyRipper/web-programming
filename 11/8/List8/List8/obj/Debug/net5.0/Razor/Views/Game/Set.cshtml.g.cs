#pragma checksum "D:\studia\sem5\.NET\11\8\List8\List8\Views\Game\Set.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f50359bf7a489529ee268cb1bc35d6856325ca18"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Set), @"mvc.1.0.view", @"/Views/Game/Set.cshtml")]
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
#line 1 "D:\studia\sem5\.NET\11\8\List8\List8\Views\_ViewImports.cshtml"
using List8;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\studia\sem5\.NET\11\8\List8\List8\Views\_ViewImports.cshtml"
using List8.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f50359bf7a489529ee268cb1bc35d6856325ca18", @"/Views/Game/Set.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9afc5bb47f4ec886805ef397b9fd6bb60a0bffb", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Set : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Ustawiono zakres na</h1>\r\n<h2>\r\n    Min: ");
#nullable restore
#line 8 "D:\studia\sem5\.NET\11\8\List8\List8\Views\Game\Set.cshtml"
    Write(ViewBag.Min);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</h2>\r\n<h2>Max: ");
#nullable restore
#line 10 "D:\studia\sem5\.NET\11\8\List8\List8\Views\Game\Set.cshtml"
    Write(ViewBag.Max);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

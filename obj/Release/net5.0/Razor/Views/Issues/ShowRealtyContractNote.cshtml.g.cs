#pragma checksum "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42723e752dab2ee33e529f1656332fe2ae8e8da6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Issues_ShowRealtyContractNote), @"mvc.1.0.view", @"/Views/Issues/ShowRealtyContractNote.cshtml")]
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
#line 1 "E:\Project\EndProject\CourtHouse\Views\_ViewImports.cshtml"
using CourtHouse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Project\EndProject\CourtHouse\Views\_ViewImports.cshtml"
using CourtHouse.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42723e752dab2ee33e529f1656332fe2ae8e8da6", @"/Views/Issues/ShowRealtyContractNote.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa1f208aa7cb897d07a95c5b57849de456a3bbdc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Issues_ShowRealtyContractNote : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CourtHouse.Models.RealtyContractNote>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal fade"" id=""ShowPopup"">
    <div class=""modal-dialog modal-xl"">
        <div class=""modal-content"">
            <div class=""modal-body"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>
                                اسم المستخدم
                            </th>
                            <th>
                                العملية
                            </th>
                            <th>
                                التاريخ
                            </th>
                            <th>
                                ملاحظة
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 26 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 30 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                               Write(Html.DisplayFor(modelItem => item.user.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 33 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                               Write(Html.DisplayFor(modelItem => item.noteType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 36 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                               Write(Html.DisplayFor(modelItem => item.noteDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 39 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                               Write(Html.DisplayFor(modelItem => item.note));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 42 "E:\Project\EndProject\CourtHouse\Views\Issues\ShowRealtyContractNote.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CourtHouse.Models.RealtyContractNote>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

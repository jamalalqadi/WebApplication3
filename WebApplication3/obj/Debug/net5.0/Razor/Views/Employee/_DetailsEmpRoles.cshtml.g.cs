#pragma checksum "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ea4511a674eaa0785049bff10129b3ce021eb91"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee__DetailsEmpRoles), @"mvc.1.0.view", @"/Views/Employee/_DetailsEmpRoles.cshtml")]
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
#line 1 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models.ViewModels.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea4511a674eaa0785049bff10129b3ce021eb91", @"/Views/Employee/_DetailsEmpRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d06b237669fa03d5989f51b7df991c73d43f300c", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee__DetailsEmpRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication3.Models.Entities.EmpRole>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <table class=\"table table-striped table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 6 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
               Write(Html.DisplayNameFor(model => model.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 12 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 414, "\"", 435, 2);
            WriteAttributeValue("", 419, "rowRole_", 419, 8, true);
#nullable restore
#line 14 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
WriteAttributeValue("", 427, item.Id, 427, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        ");
#nullable restore
#line 16 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <button class=\"btn btn-danger float-right mr-1\"");
            BeginWriteAttribute("onclick", " onclick=\"", 660, "\"", 733, 6);
            WriteAttributeValue("", 670, "Delete(\'/Employee/DeleteEmpRole/", 670, 32, true);
#nullable restore
#line 19 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
WriteAttributeValue("", 702, item.Id, 702, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 710, "\',", 710, 2, true);
            WriteAttributeValue(" ", 712, "\'#rowRole_", 713, 11, true);
#nullable restore
#line 19 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
WriteAttributeValue("", 723, item.Id, 723, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 731, "\')", 731, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"bi bi-trash3-fill\"></i> Delete</button>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 22 "C:\Users\Dell\source\repos\WebApplication3\WebApplication3\Views\Employee\_DetailsEmpRoles.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication3.Models.Entities.EmpRole>> Html { get; private set; }
    }
}
#pragma warning restore 1591

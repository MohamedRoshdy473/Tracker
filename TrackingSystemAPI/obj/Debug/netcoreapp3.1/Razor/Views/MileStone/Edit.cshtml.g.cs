#pragma checksum "D:\Tracker\TrackingSystemAPI\Views\MileStone\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04dadb5ab547413efbe97e8194e68f331fe0652b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MileStone_Edit), @"mvc.1.0.view", @"/Views/MileStone/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04dadb5ab547413efbe97e8194e68f331fe0652b", @"/Views/MileStone/Edit.cshtml")]
    public class Views_MileStone_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TrackingSystemAPI.DTO.MileStoneDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tracker\TrackingSystemAPI\Views\MileStone\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>MileStoneDTO</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
            <div class=""form-group"">
                <label asp-for=""Title"" class=""control-label""></label>
                <input asp-for=""Title"" class=""form-control"" />
                <span asp-validation-for=""Title"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""StartDate"" class=""control-label""></label>
                <input asp-for=""StartDate"" class=""form-control"" />
                <span asp-validation-for=""StartDate"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""EndDate"" class=""control-label""></label>
                <input asp-for=""EndDate"" class=""form-control"" />
                <span asp-valida");
            WriteLiteral(@"tion-for=""EndDate"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Description"" class=""control-label""></label>
                <input asp-for=""Description"" class=""form-control"" />
                <span asp-validation-for=""Description"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ProjectId"" class=""control-label""></label>
                <input asp-for=""ProjectId"" class=""form-control"" />
                <span asp-validation-for=""ProjectId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ProjectName"" class=""control-label""></label>
                <input asp-for=""ProjectName"" class=""form-control"" />
                <span asp-validation-for=""ProjectName"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""");
            WriteLiteral("btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 58 "D:\Tracker\TrackingSystemAPI\Views\MileStone\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrackingSystemAPI.DTO.MileStoneDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
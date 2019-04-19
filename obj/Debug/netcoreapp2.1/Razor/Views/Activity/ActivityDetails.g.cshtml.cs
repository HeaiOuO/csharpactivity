#pragma checksum "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2eb492f4f0d4a0c6ab66c6ecf8b1200e4c51f74e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Activity_ActivityDetails), @"mvc.1.0.view", @"/Views/Activity/ActivityDetails.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Activity/ActivityDetails.cshtml", typeof(AspNetCore.Views_Activity_ActivityDetails))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
#line 6 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
using System.Linq;

#line default
#line hidden
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\_ViewImports.cshtml"
using CSharpbelt;

#line default
#line hidden
#line 5 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
using CSharpbelt.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2eb492f4f0d4a0c6ab66c6ecf8b1200e4c51f74e", @"/Views/Activity/ActivityDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c33193876701bbf5b36d51875bdc49384863317b", @"/Views/_ViewImports.cshtml")]
    public class Views_Activity_ActivityDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSharpbelt.Models.Activity>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
  
    ViewData["Title"] = "Activity Dashboard";

#line default
#line hidden
            BeginContext(135, 173, true);
            WriteLiteral("<div class=\"header\">\r\n    <h1>Dojo Activity Center</h1>\r\n    <a id=\"home\" href=\"/Dashboard\">Activity Dashboard</a>\r\n</div>\r\n<div id=\"heading\">\r\n<h2>Name of the Activity is: ");
            EndContext();
            BeginContext(309, 11, false);
#line 12 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
                        Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(320, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 13 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
     if(ViewBag.ActiveUserId == Model.UserId)
    {

#line default
#line hidden
            BeginContext(381, 10, true);
            WriteLiteral("        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 391, "\"", 423, 2);
            WriteAttributeValue("", 398, "/Delete/", 398, 8, true);
#line 15 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
WriteAttributeValue("", 406, Model.ActivityId, 406, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(424, 64, true);
            WriteLiteral("><button class=\"btn btn-primary theButton\">Delete</button></a>\r\n");
            EndContext();
#line 16 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
    }
    else
    {
        

#line default
#line hidden
#line 19 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
         if(Model.Participants.Where(p => p.UserId == ViewBag.ActiveUserId).Count() == 0)
            {

#line default
#line hidden
            BeginContext(618, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 636, "\"", 666, 2);
            WriteAttributeValue("", 643, "/Join/", 643, 6, true);
#line 21 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
WriteAttributeValue("", 649, Model.ActivityId, 649, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(667, 72, true);
            WriteLiteral("><button class=\"btn btn-primary theButton\">JOIN Me!! :-) </button></a>\r\n");
            EndContext();
#line 22 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(787, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 805, "\"", 836, 2);
            WriteAttributeValue("", 812, "/Leave/", 812, 7, true);
#line 25 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
WriteAttributeValue("", 819, Model.ActivityId, 819, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(837, 74, true);
            WriteLiteral("><button class=\"btn btn-primary theButton\">Leave Me!!  :-( </button></a>\r\n");
            EndContext();
#line 26 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
            }

#line default
#line hidden
#line 26 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
             
    }

#line default
#line hidden
            BeginContext(933, 63, true);
            WriteLiteral("\r\n</div>\r\n<div class=\"theSections\">\r\n<h3>Activity Arranged By: ");
            EndContext();
            BeginContext(997, 25, false);
#line 31 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
                     Write(ViewBag.theUser.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1022, 117, true);
            WriteLiteral("</h3>\r\n</div>\r\n<div class=\"theSections\">\r\n<h3>Description about this Activity :</h3>\r\n<div id=\"theDescription\">\r\n    ");
            EndContext();
            BeginContext(1140, 17, false);
#line 36 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1157, 75, true);
            WriteLiteral("\r\n</div>\r\n</div>\r\n<div class=\"theSections\">\r\n<h3>Participants:</h3>\r\n<ul>\r\n");
            EndContext();
#line 42 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
 foreach(var participant in Model.Participants)
{

#line default
#line hidden
            BeginContext(1284, 21, true);
            WriteLiteral("    <li> <h4>Mr/Ms:  ");
            EndContext();
            BeginContext(1306, 40, false);
#line 44 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
                Write(participant.ParticipatingUsers.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1346, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1348, 39, false);
#line 44 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
                                                          Write(participant.ParticipatingUsers.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1387, 13, true);
            WriteLiteral(" </h4></li>\r\n");
            EndContext();
#line 45 "C:\Users\heai0\OneDrive\Desktop\CSharpbelt\Views\Activity\ActivityDetails.cshtml"
}

#line default
#line hidden
            BeginContext(1403, 13, true);
            WriteLiteral("</ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSharpbelt.Models.Activity> Html { get; private set; }
    }
}
#pragma warning restore 1591

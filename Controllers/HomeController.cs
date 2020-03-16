using RazorEngine;
using SampleWebsite.Models;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SampleWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // HtmlToPdfCoversion();
            return View();
        }

        public ActionResult UI()
        {
           // HtmlToPdfCoversion();
            return View();
        }

        public ActionResult UIHtml()
        {
            // HtmlToPdfCoversion();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "I love the pag455.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void RenderRazorHtmlViewForMailer<T>(T razorModel, string mailerPaht)
        {
            StringBuilder body = new StringBuilder();
            if (razorModel != null)
            {
                System.IO.StreamReader myrdr = new System.IO.StreamReader(mailerPaht);
                string Bodytext = myrdr.ReadToEnd();
                myrdr.Close();
                body.Append(Razor.Parse(Bodytext, razorModel));
            }

            System.IO.File.WriteAllText(mailerPaht, body.ToString());

        }

      

        public void HtmlToPdfCoversion()
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = @"F:/Sample/SampleWebsite/QtBinaries";
                //" @"F:/Sample/SampleWebsite/packages/Syncfusion.HtmlToPdfConverter.QtWebKit.WinForms.17.4.0.46/lib/QtBinaries";

            //Set Enable form to convert HTML form to PDF form

            settings.EnableForm = true;

            //Set PDF page margin 
            settings.Margin = new Syncfusion.Pdf.Graphics.PdfMargins { Top = 40, Left = 30, Right = 40, Bottom = 50 };

            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert HTML to PDF
            User user = new User();
            user.Name = "Dharmaaaa";
            RenderRazorHtmlViewForMailer<User>(user, "F:/Sample/SampleWebsite/Pdf Templates/invoice - Copy.html");
            PdfDocument document = htmlConverter.Convert("F:/Sample/SampleWebsite/Pdf Templates/invoice - Copy.html");
            //Save the PDF document 
            document.Save("F:/Sample/SampleWebsite/Pdf/HTMLToPDF.pdf");
            //Close the document
            document.Close(true);
            //This will open the PDF file so, the result will be seen in default PDF viewer
            Process.Start("F:/Sample/SampleWebsite/Pdf/HTMLToPDF.pdf");
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrashCarts.Core;
using CrashCarts.Data;
using System;

namespace CrashCarts.Pages
{
    public class addBarcodeModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IHtmlHelper htmlHelper;
        //private readonly ICovidList coviddata;
        private readonly iApp zodiacdata;

        public IEnumerable<iSciPat> ZetaData;

        //public string Message { get; set; }

        [TempData]
        public int Record { get; set; }
        [TempData]
        public string Next { get; set; }
        [TempData]
        public string CartBarcode { get; set; }
        //[TempData]
        //public string PatientID { get; set; }
        //[TempData]
        //public string CommentText { get; set; }
        /*[BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }*/
        //public string uid { get; set; }
        //public IEnumerable<SelectListItem> Block { get; set; }
        //public IEnumerable<SelectListItem> StateType { get; set; }
        //[BindProperty]
        //public iSciTest Zodiac { get; set; }
        [BindProperty]
        public iSciPat Patient { get; set; }
        //public iSciPat DupData { get; set; }
        public string name { get; set; }
        public DateTime dob { get; set; }

        public addBarcodeModel(IConfiguration config, iApp zodiacdata, IHtmlHelper htmlHelper)

        {
            this.config = config;
            this.zodiacdata = zodiacdata;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(/*string name, DateTime dob*/)

        {

            //if (Zodiac == null)
            //{
            //    return RedirectToPage("./Index");
            //}

            //Message = config["Message"];
            //SearchTerm = "O18";
            //uid = User.Identity.Name;
            //StateType = htmlHelper.GetEnumSelectList<stateType>();
            //Block = htmlHelper.GetEnumSelectList<Escal1>();
            ZetaData = zodiacdata.GetAllPatients();
            //DupData = zodiacdata.GetDupPatients(name, dob);
            Patient = new iSciPat();
            //return Page();
            return null;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                //Block = htmlHelper.GetEnumSelectList<stateType>();

                return Page();
                //return RedirectToPage("./Index");


            }

            if (Patient.id > 1)
            
            {

                return RedirectToPage("./Index");
                //return Content("<script type='text/javascript'>window.close();</script>");
            }
           
            zodiacdata.Add(Patient);
            zodiacdata.Commit();
            
            TempData["PatientID"] = "TEST"; //Patient.Cart_id;
            TempData["CommentText"] = "TEST"; //Patient.Cart_id;
            TempData["CartBarcode"] = Patient.Cart_id;
            TempData["Next"] = "./Edit/" + Patient.id;
            TempData["Record"] = Patient.id; /*+ " " + Patient.Pt_lname;*/
            return RedirectToPage("./addBarcode");

        }

    }
}

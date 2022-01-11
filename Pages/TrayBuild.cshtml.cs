using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrashCarts.Core;
using CrashCarts.Data;

namespace CrashCarts.Pages
{

    public class TrayBuildModel : PageModel
    {

        private readonly IConfiguration config;
        // private readonly ICovidList coviddata;
        private readonly iApp zodiacdata;
        private readonly IHtmlHelper htmlHelper;
        public iTray Zodiac { get; set; }
        public IEnumerable<iTrayItem> Item { get; set; }
        public IEnumerable<SelectListItem> Block { get; set; }
        [BindProperty]
        public iTrayActivityTemp TrayActivity { get; set; }
        [TempData]
        public string Barcode { get; set; }
        public int Row { get; set; }

        public TrayBuildModel(
           IConfiguration config,
           iApp zodiacdata,
           IHtmlHelper htmlHelper)

        {
            this.config = config;
            this.zodiacdata = zodiacdata;
            this.htmlHelper = htmlHelper;
        }


        public IActionResult OnGet(int TrayId, string bc)
        {
            
            Block = htmlHelper.GetEnumSelectList<YesNo>();
            Zodiac = zodiacdata.GetByIdTray(TrayId);
            Item = zodiacdata.GetAllItemsByType(Zodiac.tray_type+Zodiac.tray_slot);
            TrayActivity = new iTrayActivityTemp();
            //ZetaData = zodiacdata.GetDtlList(SearchTerm, uid);
            //labs = covidlab.IEGetByIdLab(covidId);
            if (Zodiac == null)
            {
                return RedirectToPage("./Index");
            }

            if(Barcode ==null)
            {
                Barcode = "Fix-   ";
                    }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                //Block = htmlHelper.GetEnumSelectList<stateType>();

                return Page();


            }

            if (TrayActivity.id > 1)
            {

                return RedirectToPage("./Index");
                //return Content("<script type='text/javascript'>window.close();</script>");
            }
            Row = 0;
            zodiacdata.Add(TrayActivity);
            zodiacdata.Commit();
            //TempData["Record"] = Patient.Pt_fname + " " + Patient.Pt_lname;
            //TempData["Next"] = "./Edit/" + Patient.id;
            //TempData["PatientID"] = Patient.id;
            //TempData["CommentText"] = Patient.Pt_cmttext;
            return RedirectToPage("./Tray");
        }
    }
}

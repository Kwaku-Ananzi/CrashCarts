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
    public class TrayModel : PageModel
    {

        private readonly IConfiguration config;
        private readonly IHtmlHelper htmlHelper;
        private readonly iApp trayInterface;

        public IEnumerable<iTray> Tray;


        [BindProperty]
        public iTray Trays { get; set; }
        //[BindProperty]
        public int ReturnTrayId;
        //public string trayb { get; set; }
        //[TempData]
        //public string Barcode { get; set; }
        [TempData]
        public string trayType { get; set; }
        
        [TempData]
        public int Tid { get; set; }
        public TrayModel(IConfiguration config, iApp trayInterface, IHtmlHelper htmlHelper)
        {
            this.config = config;
            this.trayInterface = trayInterface;
            this.htmlHelper = htmlHelper;

        }


        public void OnGet(string bc, int TrayId)
        {
            Tray = trayInterface.GetByBarcodeTray(bc);
            Trays = trayInterface.GetByIdTray(TrayId);
            ReturnTrayId = trayInterface.GetByBarcodeTrayId(bc);
                                 
            //Trays = trayInterface.ReturnTrayType(bc);
            //TempData["trayType"] = Trays.tray_type;
            //TempData["Barcode"] = Request.Form["bc"];

            //return Page();
            //return RedirectToPage("./TrayBuild");
            //Trays = new iTray();

            //TempData["Barcode"] = Trays.barcode;
            //return RedirectToPage("./TrayBuild");
            //return null;
        }


        public IActionResult OnPost(int id, string bc)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Trays.id > 1)
            {
                return RedirectToPage("./Index");

            }
           
           

            Tray = trayInterface.GetByBarcodeTray(bc);
            Trays = trayInterface.GetByIdTray(id);
            ReturnTrayId = trayInterface.GetByBarcodeTrayId(bc);
            //TrayId = trayInterface.BarcodeID(id);
            //TrayId = trayInterface.BarcodeID();

            TempData["Barcode"] = Request.Form["bc"].ToString();
            //TempData["Tid"] = Trays.id;

            if (ReturnTrayId < 1)
            {
                return RedirectToPage("./NotFound");
            }

            return RedirectToPage("./TrayBuild", new { TrayId = ReturnTrayId });
            //return Page();
           // return null;
           
        }


    }
}

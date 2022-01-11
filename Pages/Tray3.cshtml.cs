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
    public class Tray3Model : PageModel
    {

        private readonly IConfiguration config;
        private readonly IHtmlHelper htmlHelper;
        private readonly iApp trayInterface;

        public IEnumerable<iTrayActivity> Activity;
        [BindProperty]
        public iTrayActivity Trays { get; set; }
        //public string trayb { get; set; }

        public Tray3Model(IConfiguration config, iApp trayInterface, IHtmlHelper htmlHelper)
        {
            this.config = config;
            this.trayInterface = trayInterface;
            this.htmlHelper = htmlHelper;

        }


        public IActionResult OnGet()
        {
            Activity = trayInterface.GetAllTrayActivity();
            Trays = new iTrayActivity();
            return null;
        }
    }
}

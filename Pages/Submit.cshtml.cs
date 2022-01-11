using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrashCarts.Pages
{
    public class SubmitModel : PageModel
    {


        [TempData]
        public int Record { get; set; }
        [TempData]
        public string Next { get; set; }



        public void OnGet()
        {


        }
    }
}

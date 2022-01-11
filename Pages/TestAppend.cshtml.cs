using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrashCarts.Pages
{
    public class TestAppendModel : PageModel
    {

        public string Barcode { get; set; }

        public void OnGet()
        {
        }
    }
}

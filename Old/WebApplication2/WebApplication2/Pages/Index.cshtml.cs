using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            OkObjectResult();
        }

        public void OnGet()
        {

        }

        public IActionResult OkObjectResult()
        {
            int numberOfActions = 0;
           var responseMessage = numberOfActions != 0 ? "ok, main database created" : "main already existed, no changes were made";
            var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
            return result;
        }
    }
}

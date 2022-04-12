using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SampleCoreWebApp.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SampleCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        public IActionResult Page1()
        {
            return View();
        }

        public IActionResult Page2()
        {
            return View();
        }

        public IActionResult Concate()
        {
            var number = 100;
            List<int> multipleOfHundred = new()
            {
                number
            };
            while (number < 1000)
            {
                number += 100 - (number % 100);
                multipleOfHundred.Add(number);
            }
            ViewBag.MultipleOfHundred = $"Hello-{string.Join(",", multipleOfHundred)}";
            return View();
        }

        public IActionResult AppSettings()
        {            
            ViewBag.Appname = _appSettings.Value.AppName;
            ViewBag.SubmittedBy = _appSettings.Value.SubmittedBy;
            return View();
        }

        public IActionResult CustomValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CustomValidation(MyViewModel model)
        {
            return View(model);
        }

        public IActionResult Filing(string filingCode)
        {
            IFiling filing;

            //Switch/If else

            filing = new DomesticFiling();
            filing.GetFilingTypeFee();
            filing.GetFilingTypeCode();

            filing = new ForiegnFiling();
            filing.GetFilingTypeFee();
            filing.GetFilingTypeCode();

            filing = new PartnerShipFiling();
            filing.GetFilingTypeFee();
            filing.GetFilingTypeCode();

            return View();
        }

        private object GetFilingDetails(IFiling filing)
        {
            throw new System.NotImplementedException();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

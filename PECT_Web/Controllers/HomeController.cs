using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PECT_Web.Models;
using PECT_DLL;


namespace PECT_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Message message)
        {
            if(ModelState.IsValid)
            {
                ResultViewModel resultViewModel = new ResultViewModel();
                try
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    resultViewModel.Output = PECT_DLL.PECT_Algorithm.Encrypt(message.InputMessage, ref resultViewModel.Stages);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    if (resultViewModel.Output != null)
                    {
                        resultViewModel.Status = "COMPLETED";
                        resultViewModel.TextStatus = "text-success";
                        resultViewModel.BtnStatus = "btn-success";
                        resultViewModel.BorderStatus = "border-success";
                        resultViewModel.TimeMS = Math.Round(ts.TotalSeconds,3);
                    }
                    return View("Result", resultViewModel);
                }
                catch 
                {
                    resultViewModel.Status = "FAILED";
                    resultViewModel.TextStatus = "text-danger";
                    resultViewModel.BtnStatus = "btn-danger";
                    resultViewModel.BorderStatus = "border-danger";
                    resultViewModel.TimeMS = 0;
                    return View("Result", resultViewModel);
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Decryption()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Decryption(Message message)
        {
            if (ModelState.IsValid)
            {
                ResultViewModel resultViewModel = new ResultViewModel();
                try
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    resultViewModel.Output = PECT_DLL.PECT_Algorithm.Decrypt(message.InputMessage, ref resultViewModel.Stages);
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    if (resultViewModel.Output != null)
                    {
                        resultViewModel.Status = "COMPLETED";
                        resultViewModel.TextStatus = "text-success";
                        resultViewModel.BtnStatus = "btn-success";
                        resultViewModel.BorderStatus = "border-success";
                        resultViewModel.TimeMS = Math.Round(ts.TotalSeconds, 3);
                    }
                    return View("Result", resultViewModel);
                }
                catch
                {
                    resultViewModel.Status = "FAILED";
                    resultViewModel.TextStatus = "text-danger";
                    resultViewModel.BtnStatus = "btn-danger";
                    resultViewModel.BorderStatus = "border-danger";
                    resultViewModel.TimeMS = 0;
                    return View("Result", resultViewModel);
                }
            }
            else
            {
                return View();
            }
        }

        //public IActionResult Result()
        //{
            
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

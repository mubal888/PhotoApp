using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PhotoApp.PhotoAPI.Controllers
{
    public class HataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            // serilog nlog
            // 11-02-2020_15-02


            var logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");

            // 11/02/2020 15:30:12
            var logFileName = DateTime.Now.ToString();

            logFileName = logFileName.Replace(" ", "_");
            logFileName = logFileName.Replace(":", "-");
            logFileName = logFileName.Replace("/", "-");

            logFileName += ".txt";

            var logFilePath = Path.Combine(logFolderPath, logFileName);

            DirectoryInfo directoryInfo = new DirectoryInfo(logFolderPath);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            FileInfo fileInfo = new FileInfo(logFilePath);
            var writer = fileInfo.CreateText();
            writer.WriteLine("Hatanın gerçekleştiği yer :" + exceptionHandlerPathFeature.Error.StackTrace.Split("at")[1]); 
            writer.WriteLine("Hatanın gerçekleştiği yer :" + exceptionHandlerPathFeature.Path);

            writer.WriteLine("Hata mesajı :" + exceptionHandlerPathFeature.Error.Message);

            writer.Close();
            return View();
        }
        //public IActionResult Status(int? code)
        //{
        //    return View();
        //}

    }
}

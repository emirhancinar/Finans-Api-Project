using Finance_Api_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Finance_Api_Project.Controllers
{
    public class HomeController : Controller
    {
        //home/
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            MainModel main = new MainModel();
            return View(main);

        }
        [HttpPost]
        public async Task<IActionResult> Index(MainModel model)
        {
            var client = new HttpClient();

            string url = $"https://api.apilayer.com/exchangerates_data/convert?to={model.selectedItems.currentTo}&from={model.selectedItems.currentFrom}&amount=1";
            client.DefaultRequestHeaders.Add("apikey", "nCAn1DLahhnM7qUxojFuQxBiQhzmo0df");


            string jsonString = "";

            var stream = client.GetStreamAsync(url).Result;
            var reader = new StreamReader(stream);

            jsonString = reader.ReadToEnd();

            // "\n" karakterlerini kaldırma
            string cleanedJson = jsonString.Replace("\n", "");

            // "\\" karakterlerini kaldırma
            cleanedJson = cleanedJson.Replace("\\\\", "");

            ExchangeRate exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(cleanedJson);

            var modelx = new MainModel();
            modelx.exchange = exchangeRate;
            return View(modelx);
        }




    }
}
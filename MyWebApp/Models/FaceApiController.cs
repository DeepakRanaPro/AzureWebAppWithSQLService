using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace MyWebApp.Models
{
    public class FaceApiController : Controller
    {
        public IActionResult Index()
        {
            var client = new HttpClient();


            // Request headers

            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cf86aa3b14cf49d5b309ef18e3b0e7fc");
            var uri = "https://optumapimanager.azure-api.net/FakeRESTApi/v1/api/v1/Activities";

            var response = client.GetAsync(uri).Result;

            return View(response);
        }
    }
}

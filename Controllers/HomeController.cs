using System.Diagnostics;
using System.Net.WebSockets;
using System.Text.Json;
using ASP_Caching.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ASP_Caching.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private IMemoryCache _cache;
		public CacheKey cachekeys = new CacheKey();
        public HomeController(ILogger<HomeController> logger,IMemoryCache cache)
        {
            _logger = logger;
			_cache = cache;
        }

        public  async Task<IActionResult> IndexAsync()
        {
			using (var client = new HttpClient())
			{
				string url = "https://dummyjson.com/products";
				var uri = new Uri(url);

				// Make the HTTP request
				var response = await client.GetAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					// Access the wrapped content
					var textResult = await response.Content.ReadAsStringAsync();
					//_logger.LogInformation($"Response Data: {textResult}");

					// Deserialize JSON as needed
					var products = JsonSerializer.Deserialize<ProductResponse>(textResult, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
					_cache.Set(cachekeys.Productskey, products?.Products);


					//Log specific data
					
					return View(products.Products);
				}
				else
				{
					_logger.LogWarning($"Failed to fetch data. Status Code: {response.StatusCode}");
				}
			}


			return View();
        }
		public IActionResult Edit(int id)
		{
			try
			{
				var products = _cache.Get<List<Product>>(cachekeys.Productskey);
				Product? product = products.FirstOrDefault(e => e.productId == id);
				_logger.LogInformation(products[0].productTitle);
				return View(product);
			}
			catch
			{
				return RedirectToAction("Index");
			}
		}

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

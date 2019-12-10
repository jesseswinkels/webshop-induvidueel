using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Datamodels;
using Logic;
using Microsoft.AspNetCore.Mvc;
using webshop_induvidueel.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace webshop_induvidueel.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeLogic _homeLogic = new HomeLogic();
        private readonly CreateLogic _createLogic = new CreateLogic();

        public IActionResult Index()
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            foreach (ProductDataModel product in _homeLogic.GetAllProducts())
            {
                ProductViewModel viewModelProduct = new ProductViewModel
                {
                    Price = product.Price,
                    Name = product.Name,
                    Description = product.Description,
                    Image = product.Image,
                    Stock = product.Stock

                };
                productViewModels.Add(viewModelProduct);
            }

            IndexViewModel viewModel = new IndexViewModel
            {
                productViewModels = productViewModels
            };

            ProductViewModel Product = new ProductViewModel();

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProductViewModel product = new ProductViewModel();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel product, IFormFile image)
        {
            if (image.ContentType == "image/png" || image.ContentType == "image/jpeg")
            {
                if (image.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        product.Image = stream.ToArray();
                    }
                    //profilePicture.FileType = file.ContentType;
                   // _profilePictureLogic.UploadPicture(profilePicture, user);
                }
            }

            ProductDataModel productDataModel = new ProductDataModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
                Stock = product.Stock,
                VariationType = product.VariationType,
                VariationValue = product.VariationValue
            };

            _createLogic.CreateNewProduct(productDataModel);
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

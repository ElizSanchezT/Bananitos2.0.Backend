using Calzaditos.Models.Responses;
using Calzaditos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Calzaditos.Controllers
{
    [Route("Product")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            var products = (await _repository.GetProducts())
                .Select(x => 
                    new ProductResponse 
                    { 
                        Id = x.Id,
                        Name = x.Name,
                        Discount = x.Discount * 100,
                        DiscountedPrice = x.Price * (1 - (x.Discount ?? 0)),
                        Price = x.Price,
                        ImageUrl = x.ImageUrl,
                        BrandId = x.BrandId,
                        Sizes = x.Sizes.Select(x => x.Size).ToList()
                    });


            var result = new Response<IEnumerable<ProductResponse>>(products)
            {
                Error = "",
                IsSuccess = true,
                Message = "OK"
            };

            return Json(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repository.GetProduct(id);

            if(product is null)
            {
                return Json(new Response<ProductResponse>(null)
                {
                    Error = "No se encontró producto"
                });
            }

                
            var productResponse = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Discount = product.Discount * 100,
                DiscountedPrice = product.Price * (1 - (product.Discount ?? 0)),
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                BrandId = product.BrandId,
                Description = product.Description,
                Sizes = product.Sizes.Select(x => x.Size).ToList()
            };


            var result = new Response<ProductResponse>(productResponse)
            {
                Error = "",
                IsSuccess = true,
                Message = "OK"
            };

            return Json(result);
        }
    }
}

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
    }
}

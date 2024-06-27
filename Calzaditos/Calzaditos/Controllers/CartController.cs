using Calzaditos.Models;
using Calzaditos.Models.Responses;
using Calzaditos.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Calzaditos.Controllers
{
    [Route("Cart")]
    [Produces("application/json")]
    public class CartController : Controller
    {
        private readonly CartRepository _repository;
        public CartController(CartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCart(int id)
        {
            var cart = await _repository.GetCart(id);

            if (cart is null)
            {
                var errorResponse = new Response<CartResponse>(null)
                {
                    Error = "No se encontró carrito",
                    Message = null,
                    IsSuccess = false
                };

                return Json(errorResponse);
            }

            var cartResponse = new CartResponse
            {
                Id = id,
                UserId = cart.UserId,
                Products = cart.Products
                    .Select(p => new ProductCartResponse
                    {
                        ProductId = p.ProductId,
                        ProductDescription = p.Product.Description,
                        ProductName = p.Product.Name,
                        ProductImageUrl = p.Product.ImageUrl,
                        Size = p.Product.Size,
                        Units = p.Units
                    }).ToList(),
            };

            var response = new Response<CartResponse>(cartResponse)
            {
                Error = null,
                Message = "OK",
                IsSuccess = true
            };

            return Json(response);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(int productId, int units) 
        {
            if(units<=0) 
            {
                var errorResponse = new Response<string>(null)
                {
                    Error = "No se pueden agregar unidades no positivas",
                    Message = null,
                    IsSuccess = false
                };
                return Json(errorResponse);
            }

            var result = await _repository.AddProduct(1, productId, units); //TODO Obtener el Id del usuario autenticado

            var response = new Response<string>(null)
            {
                Error = result ? null : "No se pudo agregar el producto",
                Message = result ? "OK" : null,
                IsSuccess = result
            };

            return Json(response);
        }
    }
}

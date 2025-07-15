using Calzaditos.Models.Requests;
using Calzaditos.Models.Responses;
using Calzaditos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Calzaditos.Controllers
{
    [Route("Cart")]
    [Produces("application/json")]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;
        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("User/{userId:int}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _repository.GetCart(userId);

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
                Id = cart.Id,
                UserId = userId,
                Products = cart.Products
                    .Select(p => new ProductCartResponse
                    {
                        Id = p.ProductId,
                        Description = p.Product.Description,
                        Name = p.Product.Name,
                        Price = p.Product.Price,
                        ImageUrl = p.Product.ImageUrl,
                        Units = p.Units,
                        Size = p.SelectedSize
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

        [HttpGet]
        [Route("Cupon")]
        public async Task<IActionResult> GetCupon(string cupon)
        {
            var code = await _repository.GetCupon(cupon);
            if (code is null)
            {
                var errorResponse = new Response<PromoCodeResponse>(null)
                {
                    Error = "Cupon no existe",
                    Message = null,
                    IsSuccess = false
                };

                return Json(errorResponse);
            }
            var codeResponse = new PromoCodeResponse { Amount = code.Amount, Cupon = code.Code };
            var response = new Response<PromoCodeResponse>(codeResponse)
            {
                Error = null,
                Message = "OK",
                IsSuccess = true
            };

            return Json(response);
        }


        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductToCartRequest request) 
        {
            if(request.Quantity<0) 
            {
                var errorResponse = new Response<string>(null)
                {
                    Error = "No se pueden agregar unidades negativas",
                    Message = null,
                    IsSuccess = false
                };
                return Json(errorResponse);
            }

            var result = await _repository.AddProduct(request.UserId, request.ProductId, request.Quantity, request.Size);

            var response = new Response<string>(null)
            {
                Error = result ? null : "No se pudo agregar el producto",
                Message = result ? "OK" : null,
                IsSuccess = result
            };

            return Json(response);
        }

        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveProduct(int userId, int productId)
        {
            var result = await _repository.RemoveProduct(userId, productId);

            var response = new Response<string>(null)
            {
                Error = result ? null : "No objeto en el carrito de compras",
                Message = result ? "OK" : null,
                IsSuccess = result
            };

            return Json(response);
        }

        [HttpPost]
        [Route("Empty")]
        public async Task<IActionResult> EmptyCart(int userId)
        {
            var result = await _repository.EmptyCart(userId);

            var response = new Response<string>(null)
            {
                Error = result ? null : "No objeto en el carrito de compras",
                Message = result ? "OK" : null,
                IsSuccess = result
            };

            return Json(response);
        }

    }
}

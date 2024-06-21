using Calzaditos.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Calzaditos.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly CartRepository _repository;
        public CartController(CartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCart(int id)
        {
            var cart = _repository.GetCart(id);
            
            if(cart is null) 
            {
                return NotFound();
            }

            var response = JsonSerializer.Serialize(cart);
            return Json(response);    
        }
    }
}

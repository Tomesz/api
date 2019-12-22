using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizza.Models;

namespace pizza.Controllers
{
    // /api/Ingredients
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private pizza_dbContext _context;

        public IngredientsController(pizza_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            return Ok(_context.Ingredients.ToList());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.IngredientId == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pizza.Models;

namespace pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private pizza_dbContext _context;

        public DiscountsController(pizza_dbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAvailebleDiscounts()
        {
            var availableDiscounts = _context.Discounts.ToList().Where(d => d.Available == 1);
            if (availableDiscounts == null)
            {
                return NotFound();
            }

            return Ok(availableDiscounts);
        }

        [HttpPut("{id:int}")]
        public IActionResult SetDiscountAvaileble(int id)
        {
            var availableDiscounts = _context.Ingredients.Where(i => i.Available == 1).ToList();
            var discountToUpdate = _context.Ingredients.FirstOrDefault(i => i.IngredientId == id);
            if (availableDiscounts.Contains(discountToUpdate))
            {
                discountToUpdate.Available = 1;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult InsertDiscount(Discounts newDiscount)
        {
            _context.Discounts.Add(newDiscount);
            _context.SaveChanges();
            return StatusCode(201, newDiscount);
        }
    }
}
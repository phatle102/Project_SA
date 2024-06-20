using Client_Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client_Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly FruitableStoreContext _ctx;
        public ProductController(FruitableStoreContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _ctx.Products.ToList();
                if (products.Count == 0)
                {
                    return NotFound("Product not available");
                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _ctx.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product details not found with {id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                _ctx.Products.Add(product);
                _ctx.SaveChanges();

                return Ok("Product created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ;
        }

        [HttpPut]
        public IActionResult Put(Product model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Product Id {model.Id} is invalid");
                }
            }

            try
            {
                var product = _ctx.Products.Find(model.Id);
                if (product == null)
                {
                    return NotFound($"Product not found with id {model.Id}");
                }
                product.Name = model.Name;
                product.Img = model.Img;
                product.Description = model.Description;
                product.Price = model.Price;
                _ctx.SaveChanges();
                return Ok("Product details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _ctx.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found {id}");
                }
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
                return Ok("Product details deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult SearchByName(string keyword)
        {
            try
            {
                var result = _ctx.Products.Where(x=>x.Name.Contains(keyword)).ToList();
                if (result == null)
                {
                    return NotFound($"Cant not found product with name {keyword}");
                } 
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTop3ExpensiveProduct()
        {
            try
            {
                var topBestSaler = _ctx.Products.OrderByDescending(p => p.Price).Take(3).ToList();
                if (topBestSaler.Count == 0) return NotFound("Can not get top 3 expensive product");
                else return Ok(topBestSaler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult GetTop3BestSaler()
        {
            try
            {
                var topBestSaler = _ctx.Products.OrderByDescending(p => p.SaleRate).Take(3).ToList();
                if (topBestSaler.Count == 0) return NotFound("Can not get top 3 best saler");
                else return Ok(topBestSaler);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

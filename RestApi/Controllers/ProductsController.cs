using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.models.Const;
using RestApi.models.Entities;
using RestApi.models.Request;
using Product = RestApi.models.Entities.Product;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiVersion("1.0")]
     public class ProductsController : ControllerBase
    {
        private readonly RestApiContext _context;

        public ProductsController(RestApiContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet(ActionConst.Get)]
        // [Authorize]
        //[ResponseCache(Duration =10, Location = ResponseCacheLocation.Any)]
        [ResponseCache(CacheProfileName = "Cache")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            //var result = _context.Product.Where(x => x.ProductName.StartsWith(searchProduct)).OrderBy(x => x.Price).ToList();

            //var ProductResult = _context.Product.Where(x => x.ProductName.StartsWith(searchProduct)).AsQueryable();
            var result = await _context.Product.ToListAsync();
            if (result == null) return NotFound("No Data Found");
            return Ok(result);

            //IQueryable<Product> products;

            /* switch(sortProduct)
             {
                 case "desc":
                     products = _context.Product.OrderByDescending(x => x.Price);
                     break;
                 case "asc":
                     products = _context.Product.OrderBy(x => x.Price);
                     break;
                 default:
                     products = _context.Product;
                     break;
             }
 */
            /*if(sortProduct == "desc")
            {
                products = _context.Product.OrderByDescending(x => x.Price);
                //return products;
            }
            else if(sortProduct == "asc")
            {
                products = _context.Product.OrderBy(x => x.Price);
                //return products;
            }
            else
            {
                products = _context.Product;
               // return products;
            }*/
            //return products;
            //return await _context.Product.ToListAsync();

            // for paging take value as parameter or set default value

            /*var products = (from p in _context.Product.   //example of linq
                                               OrderBy(x => x.Id)
                            select p).AsQueryable();

           // var currentPageNumber = pageNumber ?? 1;//if pagenumber is null then set default value
          //  var currentPageSize = pageSize ?? 5; //if pagesize is null then set default value

            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = 5;

            var items = products.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize).ToList();

            return items.AsQueryable();*/

        }

        // GET: api/Products/5
        [HttpGet(ActionConst.GetById + "{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut(ActionConst.Update + "{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id,[FromBody] ProductInsertUpdaterequest product)
        {
            var products = await _context.Product.FindAsync(id);
            if (products == null) return NotFound();


            products.ProductName = product.ProductName;
            products.Price = product.Price;
            product.Description = product.Description;

            _context.Product.Update(products);
            //_context.Entry(Update).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(products);
            /*try
            {
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }*/

            //return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(ActionConst.Add)]
        public async Task<ActionResult<ProductInsertUpdaterequest>> AddProduct([FromBody] ProductInsertUpdaterequest product)
        {
            var create = new Product
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description
            };

            _context.Product.Add(create);
            await _context.SaveChangesAsync();
            return Ok(create);
            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete(ActionConst.Delete + "{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       /* private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }*/
    }
}

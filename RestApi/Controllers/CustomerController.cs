using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.models.Const;
using RestApi.models.Entities;
using RestApi.models.Request;

namespace RestApi.Controllers
{
    //[ApiVersion("2.0")]
    /*[Route("api/v{version:apiVersion}/[controller]")]*/
    [Route("api/[controller]")]
    [ApiController]
   // [Consumes("application/json;v=2.0")] // Apply version to entire controller
    public class CustomerController : ControllerBase
    {
        private readonly RestApiContext context;

        public CustomerController(RestApiContext context)
        {
            this.context = context;
        }

        [HttpGet(CustomersConst.Get)]
        public async Task<IActionResult> GetAll()
        {
            var data = await context.Customers.ToListAsync();

            if (data == null) return NotFound("No Data Found");
            
            return Ok(data);
        }

        [HttpGet(CustomersConst.GetById + "{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userExist = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (userExist == null) return NotFound("User Not Found");
            if (!ModelState.IsValid) return BadRequest();

            return Ok(userExist);
        }

        [HttpPost(CustomersConst.AddUpdate)]
        public async Task<IActionResult> InsertUpdateCustomer(CustomerInsertUpdateRequest request)
        {
            var userExist = await context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (userExist == null)
            {
                var create = new Customer
                {
                    Id = request.Id,
                    Name = request.Name,
                    Email = request.Email,
                    Phone = request.Phone
                };
                context.Customers.Add(create);
                await context.SaveChangesAsync();
                return Ok(create);
            }
            else
            {

                userExist.Name = request.Name;
                userExist.Email = request.Email;
                userExist.Phone = request.Phone;
               
                await context.SaveChangesAsync();
                return Ok(userExist);
            }
        }

        [HttpDelete(CustomersConst.Delete + "{id}")]
        public async Task<IActionResult> UserDelete(Guid id)
        {
            var userExist = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (userExist == null) return NotFound("User Not Found");
            if (!ModelState.IsValid) return BadRequest();

            context.Customers.Remove(userExist);
            await context.SaveChangesAsync();

            return Ok("User Deleted Success");
        }
    }
}

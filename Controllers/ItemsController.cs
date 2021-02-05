using MassInmemoryTransport.Messages.Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MassInmemoryTransport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private IBus _bus;
        public ItemsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("items/add")]
        public async Task<ActionResult> Create(string code, string description)
        {
            try
            {
                var msg = new ItemCreated()
                {
                    Id = 123,
                    ItemId = 321,
                    Code = code,
                    Description = description
                };
                await _bus.Publish(msg);

                return Ok(new { succeeded = true, message = "", data = msg });
            }
            catch (RequestTimeoutException)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout);
            }
            catch (Exception ex)
            {
                return Ok(new { Succeeded = false, Message = "other error: " + ex.Message });
            }
        }
    }
}

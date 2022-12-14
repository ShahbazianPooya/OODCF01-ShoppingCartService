using CustomerBasketManagement.Application.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISender _mediator;

        public CustomerController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Regsiter(CreateCustomerModel createCustomerModel)
        {
            var isCustomerRegistered = await _mediator.Send(new CreateCustomerCommand(createCustomerModel));

            return Ok(isCustomerRegistered);
        }
    }
}

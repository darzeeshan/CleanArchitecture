using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Commands;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries;
using Cone.InventoryManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientConnectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientConnectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientConnectionDetailedDto>>> Get()
        {
            var query = new GetClientConnectionListQueryRequest();
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ClientConnectionDetailedDto>> Get(int Id)
        {
            var query = new GetClientConnectionDetailWithIdQueryRequest { Id = Id };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [Route("[action]/{Id}")]
        [HttpGet]
        public async Task<ActionResult<List<ClientConnectionForSpecificSetupDto>>> GetClientConnectionForSpecificSetup(int Id)
        {
            var query = new GetClientConnectionForSpecificSetupQueryRequest { Id = Id };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] BaseClientConnectionDto entity)
        {
            var query = new CreateClientConnectionCommandRequest { createClientConnectionDto = entity };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Put(int Id, [FromBody] ClientConnectionEditDto entity)
        {
            var query = new UpdateClientConnectionCommandRequests { Id  = Id, updateClientConnectionDto = entity };
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int Id)
        {
            var response = new DeleteClientConnectionCommandRequest { Id = Id };
            var result = await _mediator.Send(response);

            return Ok(result);
        }
    }
}

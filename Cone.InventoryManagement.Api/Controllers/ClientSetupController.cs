using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Queries;
using Cone.InventoryManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cone.InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientSetupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientSetupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientSetupDetailedDto>>> Get()
        {
            var query = new GetClientSetupListQueryRequest();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ClientSetupDetailedDto>> Get(int Id)
        {
            var query = new GetClientSetupDetailWithIdQueryRequest { Id = Id };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] BaseClientSetupDto entity)
        {
            var response = new CreateClientSetupCommandRequest { createClientSetupDto = entity };
            var result = await _mediator.Send(response);

            return Ok(result);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Put(int Id, [FromBody] ClientSetupEditDto entity)
        {
            var response = new UpdateClientSetupCommandRequest { Id = Id, updateClientSetupDto = entity };
            var result = await _mediator.Send(response);

            return Ok(result);
        }

        [HttpPatch("{Id}")]
        public async Task<ActionResult<BaseCommandResponse>> Status(int Id)
        {
            ClientSetupStatusChangeDto entity = new ClientSetupStatusChangeDto { Status = 0 }; 
            //System will check existing status and change (active/inactive) accordingly

            var response = new UpdateStatusClientSetupCommandRequest { Id = Id, updateStatus = entity };
            var result = await _mediator.Send(response);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int Id)
        {
            var response = new DeleteClientSetupCommandRequest { Id  = Id };
            var result = await _mediator.Send(response);

            return Ok(result);
        }

    }
}

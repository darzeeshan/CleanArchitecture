using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Commands
{
    public class DeleteClientSetupCommandHandler : IRequestHandler<DeleteClientSetupCommandRequest, BaseCommandResponse>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public DeleteClientSetupCommandHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteClientSetupCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _clientSetupRepository.Get(request.Id);

            if (result == null)
            {
                response.ReferenceId = request.Id;
                response.StatusCode = 100;
                response.ReasonCode = 10;
                response.Message = Messages.Validation(10);
            }
            else
            {
                await _clientSetupRepository.Delete(result);

                response.ReferenceId = request.Id;
                response.StatusCode = 200;
                response.ReasonCode = 3;
                response.Message = Messages.Info(3);
            }

            return response;
        }
    }
}

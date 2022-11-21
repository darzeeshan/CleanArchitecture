using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Commands;
using Cone.InventoryManagement.Application.Responses;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Commands
{
    public class UpdateStatusClientSetupCommandHandler : IRequestHandler<UpdateStatusClientSetupCommandRequest, BaseCommandResponse>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public UpdateStatusClientSetupCommandHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateStatusClientSetupCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (request.Id <= 0)
            {
                response.ReferenceId = request.Id;
                response.StatusCode = 100;
                response.ReasonCode = 10;
                response.Message = Messages.Info(10);
            }
            else
            {
                var query = await _clientSetupRepository.Get(request.Id);

                if (query == null)
                {
                    response.ReferenceId = request.Id;
                    response.StatusCode = 100;
                    response.ReasonCode = 10;
                    response.Message = Messages.Info(10);
                }
                else
                {
                    if (query.bytStatus == 1)
                        request.updateStatus.Status = 2;
                    else
                        request.updateStatus.Status = 1;

                    _mapper.Map(request.updateStatus, query);

                    await _clientSetupRepository.Update(query);

                    response.ReferenceId = request.Id;
                    response.StatusCode = 200;
                    response.ReasonCode = 5;
                    response.Message = Messages.Info(5);
                }
            }

            return response;
        }
    }
}

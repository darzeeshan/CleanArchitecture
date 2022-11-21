using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Queries;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Queries
{
    public class GetClientSetupDetailWithIdQueryHandler : IRequestHandler<GetClientSetupDetailWithIdQueryRequest, ClientSetupDetailedDto>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public GetClientSetupDetailWithIdQueryHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }

        public async Task<ClientSetupDetailedDto> Handle(GetClientSetupDetailWithIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await _clientSetupRepository.Get(request.Id);

            return _mapper.Map<ClientSetupDetailedDto>(query);
        }
    }
}

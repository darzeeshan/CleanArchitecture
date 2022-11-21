using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Setup.Requests.Queries;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Setup.Handlers.Queries
{
    public class GetClientSetupListQueryHandler : IRequestHandler<GetClientSetupListQueryRequest, List<ClientSetupDetailedDto>>
    {
        private readonly IClientSetupRepository _clientSetupRepository;
        private readonly IMapper _mapper;

        public GetClientSetupListQueryHandler(IClientSetupRepository clientSetupRepository, IMapper mapper)
        {
            _clientSetupRepository = clientSetupRepository;
            _mapper = mapper;
        }
    
        public async Task<List<ClientSetupDetailedDto>> Handle(GetClientSetupListQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await _clientSetupRepository.GetAll();

            return _mapper.Map<List<ClientSetupDetailedDto>>(query);
        }
    }
}

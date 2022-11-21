using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Queries
{
    public class GetClientConnectionListQueryHandler : IRequestHandler<GetClientConnectionListQueryRequest, List<ClientConnectionDetailedDto>>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public GetClientConnectionListQueryHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }
    
        public async Task<List<ClientConnectionDetailedDto>> Handle(GetClientConnectionListQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await _clientConnectionRepository.GetAll();

            return _mapper.Map<List<ClientConnectionDetailedDto>>(query);
        }
    }
}

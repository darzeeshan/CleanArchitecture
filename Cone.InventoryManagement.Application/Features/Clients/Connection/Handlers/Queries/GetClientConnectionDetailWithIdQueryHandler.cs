using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Queries
{
    public class GetClientConnectionDetailWithIdQueryHandler : IRequestHandler<GetClientConnectionDetailWithIdQueryRequest, ClientConnectionDetailedDto>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public GetClientConnectionDetailWithIdQueryHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }

        public async Task<ClientConnectionDetailedDto> Handle(GetClientConnectionDetailWithIdQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await _clientConnectionRepository.Get(request.Id);

            return _mapper.Map<ClientConnectionDetailedDto>(query);
        }
    }
}

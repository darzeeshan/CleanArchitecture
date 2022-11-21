using AutoMapper;
using Cone.InventoryManagement.Application.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Application.DTOs.Clients;
using Cone.InventoryManagement.Application.Features.Clients.Connection.Requests.Queries;
using MediatR;

namespace Cone.InventoryManagement.Application.Features.Clients.Connection.Handlers.Queries
{
    public class GetClientConnectionForSpecificSetupQueryHandler : IRequestHandler<GetClientConnectionForSpecificSetupQueryRequest, List<ClientConnectionForSpecificSetupDto>>
    {
        private readonly IClientConnectionRepository _clientConnectionRepository;
        private readonly IMapper _mapper;

        public GetClientConnectionForSpecificSetupQueryHandler(IClientConnectionRepository clientConnectionRepository, IMapper mapper)
        {
            _clientConnectionRepository = clientConnectionRepository;
            _mapper = mapper;
        }

        public async Task<List<ClientConnectionForSpecificSetupDto>> Handle(GetClientConnectionForSpecificSetupQueryRequest request, CancellationToken cancellationToken)
        {
            var query = await _clientConnectionRepository.GetClientConnectionForSpecificSetup(request.Id);

            return query; //No need to AutMap data, as data is already in given DTO format.
        }
    }
}

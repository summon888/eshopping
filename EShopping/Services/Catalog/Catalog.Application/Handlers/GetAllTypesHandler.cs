using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypeQuery, IList<TypesResponse>>
    {
        private readonly ITypesRepository _typeRepository;

        public GetAllTypesHandler(ITypesRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }
        public async Task<IList<TypesResponse>> Handle(GetAllTypeQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _typeRepository.GetAllTypes();
            var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(typesList);
            return typesResponse;
        }
    }
}

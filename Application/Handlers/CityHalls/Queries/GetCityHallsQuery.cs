﻿namespace GovernmentSystem.Application.Handlers.CityHalls.Queries
{
    public class GetCityHallsQuery : IRequest<List<CityHallResponse>>
    {
    }

    public class GetCityHallsQueryHandler : IRequestHandler<GetCityHallsQuery, List<CityHallResponse>>
    {
        private readonly ICityHallService _cityHallService;

        public GetCityHallsQueryHandler(ICityHallService cityHallService)
        {
            _cityHallService = cityHallService;
        }

        public Task<List<CityHallResponse>> Handle(GetCityHallsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _cityHallService.GetCityHalls(request);
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an error retrieving the city halls", ex);
            }
        }
    }
}

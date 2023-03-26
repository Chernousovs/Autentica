using Autentica.Services.Interfaces;
using Autentica.Services.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Autentica.Services.Services
{
    public class MapDataService : IMapDataService
    {
        private readonly IMapper _mapper;
        private readonly ICsvDataReadService _csvDataReadService;

        public MapDataService(IMapper mapper, ICsvDataReadService csvDataReadService)
        {
            _mapper = mapper;
            _csvDataReadService = csvDataReadService;
        }
        public List<PlacesAndCoordinatesModel> GetMostRemotePlaces()
        {
            var places = _csvDataReadService.GetDataFromFile();

            if (places == null)
            { 
                return null;    
            }

            var N = GetNorth(places);
            var S = GetSouth(places);
            var E = GetEast(places);
            var W = GetWest(places);
           
            return new List<PlacesAndCoordinatesModel> { N, S, E, W };
        }

        private PlacesAndCoordinatesModel GetNorth(List<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderByDescending(place => place.ECoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetSouth(List<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderBy(place => place.ECoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetEast(List<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderByDescending(place => place.NCoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetWest(List<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderBy(place => place.NCoordinate).First();  
        }
    }
}

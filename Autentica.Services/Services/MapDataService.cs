using Autentica.Services.Interfaces;
using Autentica.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Autentica.Services.Services
{
    public class MapDataService : IMapDataService
    {
        private readonly ICsvDataReadService _csvDataReadService;

        public MapDataService(ICsvDataReadService csvDataReadService)
        {
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

        private PlacesAndCoordinatesModel GetNorth(IEnumerable<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderByDescending(place => place.ECoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetSouth(IEnumerable<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderBy(place => place.ECoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetEast(IEnumerable<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderByDescending(place => place.NCoordinate).First();  
        }

        private PlacesAndCoordinatesModel GetWest(IEnumerable<PlacesAndCoordinatesModel> places)
        { 
              return places.OrderBy(place => place.NCoordinate).First();  
        }
    }
}

using Autentica.Services.Interfaces;
using Autentica.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Autentica.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapDataService _mapDataService;
        
        public MapController(IMapDataService mapDataService)
        {
            _mapDataService = mapDataService;
        }

        public List<PlacesAndCoordinatesModel> GetPlaces()
        {
            return _mapDataService.GetMostRemotePlaces();
        }
    }
}

using Autentica.Models;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Autentica.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapper _mapper;

        public MapController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        public List<PlacesAndCoordinatesModel> GetPlaces()
        {
            var places = new List<CsvDataModel>();
            var Message = string.Empty;

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Comment = '#',
                HasHeaderRecord = true,
                BadDataFound = null,
            };

            

            using (var reader = new StreamReader(@"D:\C#HomeWorks\Autentica\Assignment\Assignment\aw_csv\AW_VIETU_CENTROIDI.csv"))
            using (var csv = new CsvReader(reader, configuration))
            {
                try
                {
                    places = csv.GetRecords<CsvDataModel>().ToList();
                }
                catch(Exception ex)
                {
                    Message = ex.Message;
                }                
            }

            var t = _mapper.Map<List<PlacesAndCoordinatesModel>>(places); 

            List<float> coordinates = new List<float> { };



            var N = GetNorth(t);
            var S = GetSouth(t);
            var E = GetEast(t);
            var W = GetWest(t);
           

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

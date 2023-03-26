using Autentica.Services.Interfaces;
using Autentica.Services.Models;
using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Autentica.Services.Services
{
    public class CsvDataReadService : ICsvDataReadService
    {
        private readonly IMapper _mapper;
        private const string DataFilePath = "..\\Autentica.Services\\Data\\AW_VIETU_CENTROIDI.CSV";

        public CsvDataReadService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<PlacesAndCoordinatesModel> GetDataFromFile()
        {
            List<CsvDataModel> places;
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                Comment = '#',
                HasHeaderRecord = true,
                BadDataFound = null,
            };
            
            using (var reader = new StreamReader(DataFilePath))
            using (var csv = new CsvReader(reader, configuration))
            {
                places = csv.GetRecords<CsvDataModel>().ToList();                
            }

            return _mapper.Map<List<PlacesAndCoordinatesModel>>(places); 
        }
    }
}

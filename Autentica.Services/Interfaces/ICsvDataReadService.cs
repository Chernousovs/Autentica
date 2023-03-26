using Autentica.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autentica.Services.Interfaces
{
    public interface ICsvDataReadService
    {
        List<PlacesAndCoordinatesModel> GetDataFromFile();
    }
}

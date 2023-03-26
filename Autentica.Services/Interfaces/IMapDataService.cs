using Autentica.Services.Models;
using System.Collections.Generic;

namespace Autentica.Services.Interfaces
{
    public interface IMapDataService
    {
        List<PlacesAndCoordinatesModel> GetMostRemotePlaces();
    }
}

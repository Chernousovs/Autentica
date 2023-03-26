using System.Collections.Generic;
using Autentica.Services.Interfaces;
using Autentica.Services.Models;
using Autentica.Services.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Autentica.Test
{
    public class MapDataService_Tests
    {
        private readonly IMapDataService _service;
        private readonly Mock<ICsvDataReadService> _csvDataReadServiceMock;

        public MapDataService_Tests()
        {
            _csvDataReadServiceMock = new Mock<ICsvDataReadService>();
            _service = new MapDataService(_csvDataReadServiceMock.Object);
        }

        [Test]
        public void GetMostRemotePlaces_NoDataReceived_ReturnsNull()
        {
            // Arrange
            _csvDataReadServiceMock.Setup(p => p.GetDataFromFile()).Returns((List<PlacesAndCoordinatesModel>) null);
            
            // Act
            var res = _service.GetMostRemotePlaces();

            // Assert
            res.Should().BeNull();
        }

        [Test]
        public void GetMostRemotePlaces_DataIsSet_ReturnsPlaces()
        {
            // Arrange
            var N = new PlacesAndCoordinatesModel()
            {
                Name = "North",
                ECoordinate = 50,
                NCoordinate = 25
            };

            var S = new PlacesAndCoordinatesModel()
            {
                Name = "South",
                ECoordinate = 1,
                NCoordinate = 25
            };

            var E = new PlacesAndCoordinatesModel()
            {
                Name = "East",
                ECoordinate = 25,
                NCoordinate = 50
            };

            var W = new PlacesAndCoordinatesModel()
            {
                Name = "West",
                ECoordinate = 25,
                NCoordinate = 1
            };

            var testCoordinate = new PlacesAndCoordinatesModel()
            {
                Name = "testCoordinate",
                ECoordinate =  25,
                NCoordinate = 25
            };

            List<PlacesAndCoordinatesModel> data = new List<PlacesAndCoordinatesModel>() { N, S, E, W, testCoordinate };

            _csvDataReadServiceMock.Setup(p => p.GetDataFromFile()).Returns(data);
            
            // Act
            var res = _service.GetMostRemotePlaces();

            // Assert
            res.Should().NotBeEmpty();
            res.Should().HaveCount(4);
            res.Should().BeSubsetOf(data);
            res.Should().Contain(N);
            res.Should().Contain(S);
            res.Should().Contain(E);
            res.Should().Contain(W);
            res.Should().NotContain(testCoordinate);
        }
    }
}
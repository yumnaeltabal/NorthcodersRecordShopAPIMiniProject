using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthcodersRecordShopAPIMiniProject.Controllers;
using NorthcodersRecordShopAPIMiniProject.Repositories;
using NorthcodersRecordShopAPIMiniProject.Services;
using NorthcodersRecordShopAPIMiniProject.Models;
using Microsoft.AspNetCore.Mvc; 
using Moq;
using Shouldly;


namespace RecordShopTests
{
    public class AlbumControllerTest
    {
        private AlbumController _albumController;
        private Mock<IAlbumService> _mockAlbumService;

        [SetUp]
        public void Setup()
        {
            _mockAlbumService = new Mock<IAlbumService>();
            _albumController = new AlbumController(_mockAlbumService.Object);
        }
        [Test]
        public void GetAlbumsTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre");
            var albumsList = new List<Album>();
            _mockAlbumService
                            .Setup(service => service.GetAllAlbums())
                            .Returns(albumsList);
            var actual = (OkObjectResult)_albumController.GetAllAlbums();
            actual.StatusCode.ShouldBe(200);
            actual.Value.ShouldBe(albumsList);
        }
        [Test]
        public void GetAlbumByIdTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre") { Id = 1 };
            _mockAlbumService
                            .Setup(service => service.GetAlbumById(1))
                            .Returns(album);
            var actual = (OkObjectResult)_albumController.GetAlbumById(1);
            actual.StatusCode.ShouldBe(200);
            actual.Value.ShouldBe(album);
        }
        [Test]
        public void GetAlbumById_NotFoundTest()
        {
            _mockAlbumService
                            .Setup(service => service.GetAlbumById(1))
                            .Returns((Album)null);
            var actual = (NotFoundResult)_albumController.GetAlbumById(1);
            actual.StatusCode.ShouldBe(404);
        }
    }
}
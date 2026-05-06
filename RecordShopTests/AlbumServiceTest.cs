using Microsoft.AspNetCore.Mvc;
using NorthcodersRecordShopAPIMiniProject.Controllers;
using NorthcodersRecordShopAPIMiniProject.Repositories;
using NorthcodersRecordShopAPIMiniProject.Services;
using NorthcodersRecordShopAPIMiniProject.Models;
using Moq;
using Shouldly;

namespace RecordShopTests
{
    public class Tests
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
            var albumsList = new List<Album> { album };

            _mockAlbumService
                            .Setup(service => service.GetAllAlbums())
                            .Returns(albumsList);

            var result = _albumController.GetAllAlbums();

            result.ShouldBeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.ShouldBe(albumsList);
        }
        [Test]
        public void GetAlbumByIdTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre") { Id = 1 };
            var albumsList = new List<Album> { album };

            _mockAlbumService
                            .Setup(service => service.GetAlbumById(1))
                            .Returns(album);

            var result = _albumController.GetAlbumById(1);

            result.ShouldBeOfType<OkObjectResult>();

            var okResult = result as OkObjectResult;
            okResult.Value.ShouldBe(album);
        }
        [Test]
        public void GetAlbumById_NotFoundTest()
        {
            _mockAlbumService
                            .Setup(service => service.GetAlbumById(1))
                            .Returns((Album)null);
            var result = _albumController.GetAlbumById(1);

            result.ShouldBeOfType<NotFoundResult>();

            var notFoundResult = result as NotFoundResult;
            notFoundResult.StatusCode.ShouldBe(404);
        }
        [Test]
        public void PostNewAlbumTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre") { Id = 1 };
            _mockAlbumService
                            .Setup(service => service.PostNewAlbum(album))
                            .Returns(album);
            var result = _albumController.PostNewAlbum(album);
            result.ShouldBeOfType<CreatedAtActionResult>();
            var createdAtActionResult = result as CreatedAtActionResult;
            createdAtActionResult.Value.ShouldBe(album);
        }
        [Test]
        public void DeleteAnAlbumTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre") { Id = 1 };
            _mockAlbumService
                            .Setup(service => service.DeleteAnAlbum(1))
                            .Returns(album);
            var result = _albumController.DeleteAnAlbum(1);
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.ShouldBe(album);
        }
        [Test]
        public void DeleteAnAlbum_NotFoundTest()
        {
            _mockAlbumService
                            .Setup(service => service.DeleteAnAlbum(1))
                            .Returns((Album)null);
            var result = _albumController.DeleteAnAlbum(1);
            result.ShouldBeOfType<NotFoundResult>();
            var notFoundResult = result as NotFoundResult;
            notFoundResult.StatusCode.ShouldBe(404);
        }
        [Test]
        public void UpdateAnAlbumTest()
        {
            var album = new Album("Test Album", "Test Artist", 2000, "Test Genre") { Id = 1 };
            var updatedAlbum = new Album("Updated Album", "Updated Artist", 2020, "Updated Genre") { Id = 1 };
            _mockAlbumService
                            .Setup(service => service.UpdateAnAlbum(1, updatedAlbum))
                            .Returns(updatedAlbum);
            var result = _albumController.UpdateAnAlbum(1, updatedAlbum);
            result.ShouldBeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.ShouldBe(updatedAlbum);
        }
        [Test]
        public void UpdateAnAlbum_NotFoundTest()
        {
            var updatedAlbum = new Album("Updated Album", "Updated Artist", 2020, "Updated Genre") { Id = 1 };
            _mockAlbumService
                            .Setup(service => service.UpdateAnAlbum(1, updatedAlbum))
                            .Returns((Album)null);
            var result = _albumController.UpdateAnAlbum(1, updatedAlbum);
            result.ShouldBeOfType<NotFoundResult>();
            var notFoundResult = result as NotFoundResult;
            notFoundResult.StatusCode.ShouldBe(404);
        }
    }
}
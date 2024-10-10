using BooksAPI.Controllers;
using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;
using BooksAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace BooksAPITests
{
    public class BooksControllerTests
    {
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _controller = new BooksController();
        }

        [Fact]
        public void GetAllBooks_ReturnsOkResult_WithBooks()
        {
            // Act
            var result = _controller.GetAllBooks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
            Assert.Equal(3, books.Count()); // Check initial book count
        }

        [Fact]
        public void GetBookById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            int bookId = 1;

            // Act
            var result = _controller.GetBookById(bookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var book = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(bookId, book.Id);
        }
    }
}
        
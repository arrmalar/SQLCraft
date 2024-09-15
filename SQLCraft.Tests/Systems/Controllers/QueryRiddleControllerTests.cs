using Moq;
using Moq.Protected;
using SQLCraftFront.Repositories;
using System.Net;
using System.Text.Json;

namespace SQLCraft.Tests.Systems.Controllers
{
    public class QueryRiddleControllerTests
    {
        /*private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly QueryRiddleRepository _repository;

        public QueryRiddleControllerTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _repository = new QueryRiddleRepository(_httpClient);
        }*/

        [Fact]
        public void Get_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            //var controller = new QueryRiddleController();
            // Act

            // Assert
        }

        /*[Theory]
        [InlineData("1")]
        [InlineData("2")]
        public void Test2(string input)
        {

        }*/

        /*[Fact]
        public async Task Get_WhenSuccessful()
        {
            // Arrange
            var testQueryRiddleDTO = new QueryRiddleDTO {
                
            };
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(testQueryRiddleDTO))
            };

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString().Contains("/api/queryRiddle/18")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage);

            // Act
            var result = await _repository.Get(18);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testQueryRiddleDTO.Question, result.Question);
        }

        [Fact]
        public async Task Get_WhenNotSuccessful()
        {
            // Arrange
            var testQueryRiddleDTO = new QueryRiddleDTO { };
            var responseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonSerializer.Serialize(testQueryRiddleDTO))
            };

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get && req.RequestUri.ToString().Contains("/api/queryRiddle/1")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(responseMessage);

            // Act
            var result = await _repository.Get(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(testQueryRiddleDTO.Question, result.Question);
        }*/
    }
}
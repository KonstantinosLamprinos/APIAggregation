using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AggregationService.Interfaces;
using Moq;
using Moq.Protected;
using Xunit;


namespace AggregationService.Tests
{
    public class RetrieveDataServiceUnitTests
    {
        
        //[Fact]
        //public async Task RetrieveData_WhenResponseIs200_LoadsXmlWithoutThrowing()
        //{
        //    // Arrange
        //    const string xml = "<root><item id=\"1\" /></root>";

        //    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        //    handlerMock
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            ItExpr.IsAny<HttpRequestMessage>(),
        //            ItExpr.IsAny<CancellationToken>())
        //        .ReturnsAsync(() => new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.OK,
        //            Content = new StringContent(xml)
        //        })
        //        .Verifiable();

        //    var httpClient = new HttpClient(handlerMock.Object, disposeHandler: false);

        //    var apiMock = new Mock<IAPI>();
        //    apiMock.Setup(a => a.GetSource).Returns("https://example.com/data.xml");

        //    var dataService = new RetrieveDataService(httpClient, apiMock.Object);

        //    // Act (should not throw)
        //    await dataService.RetrieveDataAsync(apiMock);

        //    // Assert - verify request was sent to the expected URL
        //    handlerMock.Protected().Verify(
        //                    "SendAsync",
        //                    Times.Once(),
        //                    ItExpr.Is<HttpRequestMessage>(r =>
        //                        r.Method == HttpMethod.Get &&
        //                        r.RequestUri == new Uri("https://example.com/data.xml")),
        //                    ItExpr.IsAny<CancellationToken>());
        //}

        //[Fact]
        //public async Task RetrieveData_WhenResponseIs500_ThrowsHttpRequestException()
        //{
        //    // Arrange
        //    var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        //    handlerMock
        //        .Protected()
        //        .Setup<Task<HttpResponseMessage>>(
        //            "SendAsync",
        //            ItExpr.IsAny<HttpRequestMessage>(),
        //            ItExpr.IsAny<CancellationToken>())
        //        .ReturnsAsync(() => new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.InternalServerError,
        //            Content = new StringContent("oops")
        //        });

        //    var httpClient = new HttpClient(handlerMock.Object, disposeHandler: false);

        //    var apiMock = new Mock<IAPI>();
        //    apiMock.Setup(a => a.GetSource).Returns("https://example.com/data.xml");

        //    var dataService = new RetrieveDataService(httpClient, apiMock.Object);

        //    // Act + Assert
        //    await Assert.ThrowsAsync<HttpRequestException>(() => dataService.RetrieveDataAsync(apiMock));
        //}
        
    }
}

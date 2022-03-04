using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Helpers{
    internal static class MockHttpMessageHandler<T>{
        internal static class Mock<MockHttpMessageHandler> SetupBasicGetResourceList(List<T> expectedFResponse){
            var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK){
                Content = new StringContent(JsonConvert.SerializeObject(expectedFResponse))
            
            };
            mockResponse.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnAsync(mockResponse);
            return handlerMock;
           
        }
        internal static Mock<HttpMessageHandler> SetupReturn404() {
                var mockResponse = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound){
                Content = new StringContent("")
            };
            mockResponse.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            
            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnAsync(mockResponse);
            return handlerMock;
           
        }
        internal static object SetupBasicGetResourceList(List<User> expectedResponse, string endpoint){
            throw new NotImplementedException();
        }
    }

}
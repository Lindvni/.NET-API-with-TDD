using CloudCustomers.UnitTests.Fixtures;
using CloudCustomers.UnitTests.Helpers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using XUnit;


namespace CloudCustomers.UnitTests.Systems.Services{
    public class TestUsersService{
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokeHttpGetRequest(){
            //Arrange
            var sut = new UserFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupGetBasicResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            await sut.GetAlUsers();

            //Assert
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                );

        }


        [Fact]
        public async Task GetAllUsers_WhenaHits404_ReturnsEmptyListOfUsers(){
            var sut = new UserFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>.Setupreturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            result = await sut.GetAlUsers();

            //Assert
            result.Count.Should().Be(0);

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsersOfExpectedSize(){
            var sut = new UserFixture.GetTestUsers();

            var handlerMock = MockHttpMessageHandler<User>.Setupreturn404();
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UserService(httpClient);

            //Act
            result = await sut.GetAlUsers();

            //Assert
            result.Count.Should().Be(expectedResponse.Count);

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl(){
            var sut = new UserFixture.GetTestUsers();
            var endpoint ="https://example.com/users";
            var handlerMock = MockHttpMessageHandler<User>
            .SetupBasicResourceList(expectedResponse,endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UsersApiOptions {
                Endpoint = "https://example.com/users"
            });

            var sut = new UsersService(httpClient,config);

            //Act
            result = await sut.GetAlUsers();

            //Assert
          

        }
    }
    
}
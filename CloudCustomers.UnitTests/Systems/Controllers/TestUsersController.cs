using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using CloudCustomers.API.Models;
using CloudCustomers.API.Models;
using System.Threading.Tasks;
using Xunit;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class UnitTest1
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsListOfUsers()
    {
        //Arrange
        var mockUsersService = Mock<IUsersService>();

        mockUsersService
            .Setup(service => service.GetAllUsers()).ReturnAsync(new List<User>()
            {
                new()
            {
                Id =1,
                Name = "Jane",
                Address = new Address(){
                   Street = "123 Main St",
                   City = "Madison",
                   Zipcode = "5378"
               },
               Email = "lindaniben20@gmail.com"

            }
        } );
        
        var sut = new UsersControllers(mockUsersService.Object);
        

        //Act 
        var result = (OkObjectResult)await sut.Get();
        
        //Assert
        result.StatusCode.Should().Be(200);


    }
    [Fact]
    public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()
    {
        //Arrange
        var mockUsersService = Mock<IUsersService>();

        mockUsersService
            .Setup(service => service.GetAllUsers()).ReturnAsync(new List<User>());
        
        var sut = new UsersControllers(mockUsersService.Object);
        
        //Act
        var result = (OkObjectResult)await sut.Get();        
    
        //Assert
        mockUsersService.Verify(
            service => service.GetAllUsers(),
            Times.Once()
        );
    }
    [Fact]
    public async Task Get_OnSuccess_InvokeUserServiceExactlyOnce()
    {
        //Arrange
        var mockUsersService = Mock<IUsersService>();

        mockUsersService
            .Setup(service => service.GetAllUsers()).ReturnAsync(new List<User>());
        
        var sut = new UsersControllers(mockUsersService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        object p = objectResult.Value.Should().BeOfType<List<User>>();
    }
    
    [Fact]
    public async Task Get_OnNoUsersFound_Returns404()
    {
        //Arrange
        var mockUsersService = Mock<IUsersService>();

        mockUsersService
            .Setup(service => service.GetAllUsers()).ReturnAsync(new List<User>());
        
        var sut = new UsersControllers(mockUsersService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);
    }
}

}
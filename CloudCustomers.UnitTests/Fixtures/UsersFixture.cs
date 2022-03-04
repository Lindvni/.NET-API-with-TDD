using CloudCustomers.API.Models;
using System.Collections.Generic;

namespace CloudCustomers.UnitTests.Fixtures{
    public static class UsersFixtures{
        public static List<User>GetTestUsers() => new(){
            new User{
                 Name = "Test User 1",
                 Email = "test.dev@gmail.com"
                 Address = new Address(){
                   Street = "123 Market St",
                   City = "Madi",
                   Zipcode = "53789"
            }
        },
        new User{
                 Name = "Test User 1",
                 Email = "test.dev@gmail.com"
                 Address = new Address(){
                   Street = "123 Market St",
                   City = "Madi",
                   Zipcode = "53789"
                }
        },
    }
}
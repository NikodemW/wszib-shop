using AutoMapper;
using FluentAssertions;
using Moq;
using Shop.Core.Domain;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using Shop.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shop.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public void get_should_return_user()
        {
            //Mock
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();
            
            var user = new User("test@test.com", "secret");
            userRepositoryMock.Setup(x => x.Get(user.Email)).Returns(user);
            mapperMock.Setup(x => x.Map<UserDto>(user)).Returns(new UserDto
            {
                Id = user.Id,
                Email = user.Email
            });

            IUserService userService = new UserService(userRepositoryMock.Object, mapperMock.Object);

            var userDto = userService.Get(user.Email);

            userDto.Should().NotBeNull();
            userDto.Id.ShouldBeEquivalentTo(user.Id);
            userRepositoryMock.Verify(x => x.Get(user.Email), Times.Once);
            mapperMock.Verify(x => x.Map<UserDto>(user), Times.Once);
        }
    }
}

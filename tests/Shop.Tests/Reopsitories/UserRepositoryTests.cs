using AutoFixture;
using FluentAssertions;
using Shop.Core.Domain;
using Shop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Shop.Tests.Reopsitories
{
    public class UserRepositoryTests
    {
        [Fact]
        public void adding_the_user_should_succeed()
        {
            //Arrange
            IUserRepository userRepository = new UserRepository();
            var fixture = new Fixture();
            var user = fixture.Create<User>();

            //Act

            userRepository.Add(user);


            //Assert

            var expectedUser = userRepository.Get(user.Id);
            var expectedUser2 = userRepository.Get(user.Email);

            user.ShouldBeEquivalentTo(expectedUser);
            user.ShouldBeEquivalentTo(expectedUser2);

            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Email, user.Email);
            Assert.NotNull(expectedUser);

            

            Assert.Equal(expectedUser2.Id, user.Id);
            Assert.Equal(expectedUser2.Email, user.Email);
            Assert.NotNull(expectedUser2);
        }
    }
}

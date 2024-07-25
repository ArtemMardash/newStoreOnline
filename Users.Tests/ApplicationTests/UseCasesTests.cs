using FluentAssertions;
using NSubstitute;
using Users.Application.Dtos;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Users.Domain.Events;
using Users.Domain.ValueObjects;

namespace Users.Tests.ApplicationTests;

public class UseCasesTests
{
    [Fact]
    public async Task Create_User_Should_Successfull()
    {
        var dto = new CreateUserDto
            { Email = "artiMar@gmail.com", PhoneNumber = "1231231234", FirstName = "Artem", LastName = "Mardakhaev"};
        var user = new User(dto.Email, dto.PhoneNumber, new FullName(dto.FirstName, dto.LastName));
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        await unitOfWorkMock.SaveChangesAsync(CancellationToken.None);
        var repositoryMock = Substitute.For<IUserRepository>();
        await repositoryMock.AddUserAsync(Arg.Any<User>(), CancellationToken.None);
        repositoryMock.GetUserAsync(Arg.Any<Guid>(), CancellationToken.None).Returns(user);

        await repositoryMock.AddUserAsync(user,CancellationToken.None);

        var result = await repositoryMock.GetUserAsync(user.Id.SystemId, CancellationToken.None);

        result.Should().Be(user);
    }

    [Fact]
    public async Task Create_User_Should_Fail()
    {
        var dto = new CreateUserDto
            { Email = "artiMar@gmail.com", PhoneNumber = "1231231234", FirstName = "Artem", LastName = "Mardakhaev"};
        var user = new User(dto.Email, dto.PhoneNumber, new FullName(dto.FirstName, dto.LastName));
        var unitOfWorkMock = Substitute.For<IUnitOfWork>();
        await unitOfWorkMock.SaveChangesAsync(CancellationToken.None);
        var repositoryMock = Substitute.For<IUserRepository>();
        await repositoryMock.AddUserAsync(Arg.Any<User>(), CancellationToken.None);
        repositoryMock.GetUserAsync(Arg.Any<Guid>(), CancellationToken.None).Returns(user);

        await repositoryMock.AddUserAsync(user,CancellationToken.None);

        var result = await repositoryMock.GetUserAsync(user.Id.SystemId, CancellationToken.None);

        result.Should().Be(null);
    }
}
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NumbersApp.WEB.Controllers;
using NumbersApp.WEB.EF.Entities;
using NumbersApp.WEB.Interfaces;
using Xunit;

namespace NumbersApp.WEB.Tests.Controllers;

public class NumbersControllerTests
{
    private readonly Mock<INumbersRepository> _numbersRepositoryMock;
    private readonly NumbersController _numbersController;

    public NumbersControllerTests()
    {
        _numbersRepositoryMock = new Mock<INumbersRepository>();
        _numbersController = new NumbersController(_numbersRepositoryMock.Object);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(312)]
    public async Task IsThisAPrimeNumber_Should_Return_BadRequest_When_Number_Not_Prime(int number)
    {
        //Act
        var actual = await _numbersController.IsThisAPrimeNumber(number);

        //Assert
        actual.Should().BeOfType<BadRequestObjectResult>();
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(997)]
    public async Task IsThisAPrimeNumber_Should_Return_Ok_When_Number_Prime(int number)
    {
        //Act
        var actual = await _numbersController.IsThisAPrimeNumber(number);

        //Assert
        actual.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task IsThisAPrimeNumber_Should_Look_For_Number_In_Repository()
    {
        //Arrange
        var number = new Random().Next();

        //Act
        await _numbersController.IsThisAPrimeNumber(number);

        //Assert
        _numbersRepositoryMock.Verify(x => x.GetByValueAsync(number), Times.Once);
    }

    [Fact]
    public async Task IsThisAPrimeNumber_Should_Create_New_When_Number_Not_Found()
    {
        //Arrange
        _numbersRepositoryMock
            .Setup(x => x.GetByValueAsync(It.IsAny<int>()))
            .ReturnsAsync(null as Number);

        //Act
        await _numbersController.IsThisAPrimeNumber(new Random().Next());

        //Assert
        _numbersRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Number>()), Times.Once);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task IsThisAPrimeNumber_Should_Not_Create_New_When_Number_Found(bool isPrime)
    {
        //Arrange
        var random = new Random();

        var entity = new Number
        {
            Value = random.Next(),
            IsPrime = isPrime
        };

        _numbersRepositoryMock
            .Setup(x => x.GetByValueAsync(It.IsAny<int>()))
            .ReturnsAsync(entity);

        //Act
        await _numbersController.IsThisAPrimeNumber(random.Next());

        //Assert
        _numbersRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Number>()), Times.Never);
    }
}
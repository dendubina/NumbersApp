using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NumbersApp.WEB.Controllers;
using NumbersApp.WEB.Interfaces;
using Xunit;

namespace NumbersApp.WEB.Tests.Controllers;

public class NumbersControllerTests
{
    private readonly Mock<INumbersService> _numbersServiceMock;
    private readonly NumbersController _numberController;

    public NumbersControllerTests()
    {
        _numbersServiceMock = new Mock<INumbersService>();
        _numberController = new NumbersController(_numbersServiceMock.Object);
    }

    [Fact]
    public void IsThisAPrimeNumber_Should_Return_BadRequest_When_Number_Not_Prime()
    {
        //Arrange
        _numbersServiceMock
            .Setup(x => x.IsPrime(It.IsAny<int>()))
            .Returns(false);

        //Act
        var actual = _numberController.IsThisAPrimeNumber(new Random().Next());

        //Assert
        actual.Should().BeOfType<BadRequestObjectResult>();
    }

    [Fact]
    public void IsThisAPrimeNumber_Should_Return_Ok_When_Number_Prime()
    {
        //Arrange
        _numbersServiceMock
            .Setup(x => x.IsPrime(It.IsAny<int>()))
            .Returns(true);

        //Act
        var actual = _numberController.IsThisAPrimeNumber(new Random().Next());

        //Assert
        actual.Should().BeOfType<OkObjectResult>();
    }
}
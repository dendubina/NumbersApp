using FluentAssertions;
using NumbersApp.WEB.Services;
using Xunit;

namespace NumbersApp.WEB.Tests.Services;

public class NumbersServiceTests
{
    private readonly NumbersService _numbersService = new();

    [Theory]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(100)]
    public void IsPrime_Should_Return_False_When_Number_Not_Prime(int number)
    {
        //Act
        var actual = _numbersService.IsPrime(number);

        //Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(347)]
    public void IsPrime_Should_Return_True_When_Number_Prime(int number)
    {
        //Act
        var actual = _numbersService.IsPrime(number);

        //Assert
        actual.Should().BeTrue();
    }
}
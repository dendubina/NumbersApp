using NumbersApp.WEB.Interfaces;

namespace NumbersApp.WEB.Services;

public class NumbersService : INumbersService
{
    public bool IsPrime(int number)
    {
        var counter = 0;

        for (var i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                counter = 1;
                break;
            }
        }

        return counter == 0;
    }
}
namespace NumbersApp.WEB.Extensions;

public static class IntExtensions
{
    public static bool IsPrime(this int value)
    {
        if (value < 2)
        {
            return false;
        }

        for (var i = 2; i < value; i++)
        {
            if (value % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
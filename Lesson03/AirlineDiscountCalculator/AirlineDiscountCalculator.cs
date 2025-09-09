namespace AirlineDiscountCalculator;

public class AirlineDiscountCalculator
{
    public int CalculateDiscount(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum)
    {
        if (age is < 0 or >= 130)
        {
            throw new ArgumentOutOfRangeException(nameof(age));
        }

        var sixDayDiscount = stayForSixDaysMinimum ? 10 : 0;

        if (age <= 2)
        {
            return 100;
        }

        if (age is > 2 and < 18)
        {
            return 40 + sixDayDiscount;
        }

        if (!mondayOrFriday)
        {
            if (toIndia)
            {
                return 20 + sixDayDiscount;
            }

            return 25 + sixDayDiscount;
        }

        return sixDayDiscount;
    }
}
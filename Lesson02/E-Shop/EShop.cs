namespace E_ShopLibrary;

public class EShop
{
    public int CalculateDiscount(double purchaseAmount)
    {
        return purchaseAmount switch
        {
            < 0 => throw new ArgumentException("purchase amount cannot be less than 0"),
            <= 300 => 0,
            > 300 and <= 800 => 5,
            _ => 10
        };
    }
}
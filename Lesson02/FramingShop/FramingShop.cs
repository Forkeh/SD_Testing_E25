namespace FramingShop;

public class FramingShop
{
    public int CalculateFramePrice(int width, int height)
    {
        switch (width)
        {
            case < 30:
                throw new ArgumentException("Frame width must be at least 30");
            case > 100:
                throw new ArgumentException("Frame width must be maximum 100");
        }

        switch (height)
        {
            case < 30:
                throw new ArgumentException("Frame height must be at least 30");
            case > 60:
                throw new ArgumentException("Frame height must be maximum 60");
        }

        var frameSurface = width * height;

        return frameSurface > 1600 ? 3500 : 3000;
    }
}
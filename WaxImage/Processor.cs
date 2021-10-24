using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace WaxImage;

public class Processor
{
    /// <summary>
    /// Filter the color from image
    /// </summary>
    /// <param name="img">Reference of image in ARGB32 format</param>
    /// <param name="filter">The filter to be applied</param>
    public static void ColorFilter(ref Image<Argb32> img, Argb32 filter)
    {
        for (int x = 0; x < img.Width; x++)
        for (int y = 0; y < img.Height; y++)
        {
            Argb32 color = img[x, y];

            byte red = (byte) Math.Clamp((int) color.R, 0, filter.R);
            byte green = (byte) Math.Clamp((int) color.G, 0, filter.G);
            byte blue = (byte) Math.Clamp((int) color.B, 0, filter.B);

            img[x, y] = new Argb32(red, green, blue);
        }
    }

    /// <summary>
    /// Apply brightness to image
    /// </summary>
    /// <param name="img">Reference of image in ARGB32 format</param>
    /// <param name="brightness">The brightness amount</param>
    public static void Brightness(ref Image<Argb32> img, int brightness)
    {
        for (int x = 0; x < img.Width; x++)
        for (int y = 0; y < img.Height; y++)
        {
            Argb32 color = img[x, y];
            
            byte red = (byte) Math.Clamp(color.R + brightness, 0, 255);
            byte green = (byte) Math.Clamp(color.G + brightness, 0, 255);
            byte blue = (byte) Math.Clamp(color.B + brightness, 0, 255);

            img[x, y] = new Argb32(red, green, blue);
        }
    }

    /// <summary>
    /// Apply gamma to image
    /// </summary>
    /// <param name="img">Reference of image in ARGB32 format</param>
    /// <param name="gamma">The gamma amount</param>
    public static void Gamma(ref Image<Argb32> img, float gamma)
    {
        for (int x = 0; x < img.Width; x++)
        for (int y = 0; y < img.Height; y++)
        {
            Argb32 color = img[x, y];

            byte red = (byte) (255 * Math.Pow((float) color.R / 256, gamma));
            byte green = (byte) (255 * Math.Pow((float) color.G / 256, gamma));
            byte blue = (byte) (255 * Math.Pow((float) color.B / 256, gamma));
            
            img[x, y] = new Argb32(red, green, blue);
        }
    }
    
    /// <summary>
    /// Invert the image color
    /// </summary>
    /// <param name="img">Reference of image in ARGB32 format</param>
    public static void InvertColor(ref Image<Argb32> img)
    {
        for (int x = 0; x < img.Width; x++)
        for (int y = 0; y < img.Height; y++)
        {
            Argb32 color = img[x, y];

            byte red = (byte) (255 - color.R);
            byte green = (byte) (255 - color.G);
            byte blue = (byte) (255 - color.B);

            img[x, y] = new Argb32(red, green, blue);
        }
    }

    /// <summary>
    /// Apply contrast to image
    /// </summary>
    /// <param name="img">Reference of image in ARGB32 format</param>
    /// <param name="contrast">The contrast amount</param>
    public static void Contrast(ref Image<Argb32> img, int contrast)
    {
        for (int x = 0; x < img.Width; x++)
        for (int y = 0; y < img.Height; y++)
        {
            Argb32 color = img[x, y];

            int factor = 259 * (contrast + 255) / (255 * (259 - contrast));
            
            byte red = (byte) Math.Clamp(color.R * factor, 0, 255);
            byte green = (byte) Math.Clamp(color.G * factor, 0, 255);
            byte blue = (byte) Math.Clamp(color.B * factor, 0, 255);
            
            img[x, y] = new Argb32(red, green, blue);
        }
    }
}
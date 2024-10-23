using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ConsoleGraphics;

class Program
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        using (Image<Rgba32> image = Image.Load<Rgba32>(""))
        {
            Draw.DrawImage(image);
        }
        
        Console.ReadKey();
    }
}
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ConsoleGraphics;

internal static class Program
{
    static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        using (Image<Rgba32> image = Image.Load<Rgba32>(args[0]))
        {
            Draw.DrawImage(Draw.ResizeImage(image,Console.WindowWidth,Console.WindowHeight));
        }
        
        Console.ReadKey();
    }
}
﻿using System.Collections.Concurrent;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace ConsoleGraphics;

public static class Draw
{
    private const char Base = '█';
    
    public static void DrawImage(Image<Rgba32> image)
    {
        // Concurrent collection to store lines with their row index
        var lines = new ConcurrentBag<(int Row, string Line)>();

        Parallel.For(0, image.Height, y =>
        {
            // Using StringBuilder for better performance in string concatenation
            var lineBuilder = new StringBuilder();

            for (int x = 0; x < image.Width; x++)
            {
                var pixelColor = image[x, y];
                var c = new CustomColor(pixelColor.R, pixelColor.G, pixelColor.B);

                lineBuilder.Append(c);
                lineBuilder.Append(Base);
            }
            
            // Add the line along with its row index to the concurrent bag
            lines.Add((y, lineBuilder.ToString()));
        });

        // Sort the lines by their row index and print them in order
        foreach (var line in lines.OrderBy(item => item.Row))
        {
            Console.WriteLine(line.Line);
        }
    }
    
    public static Image<Rgba32> ResizeImage(Image<Rgba32> image, int outputWidth, int outputHeight)
    {
        // Load the image from file
        using (image)
        {
            // Resize the image to the desired dimensions
            image.Mutate(x => x.Resize(outputWidth, outputHeight));

            // Clone the image into a new Image<Rgba32> to return
            return image.Clone();
        }
    }
}
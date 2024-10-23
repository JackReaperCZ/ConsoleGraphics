namespace ConsoleGraphics;

internal readonly struct CustomColor(int r, int g, int b)
{
    public override string ToString()
    {
        return $"\x1b[38;2;{r};{g};{b}m";
    }
}
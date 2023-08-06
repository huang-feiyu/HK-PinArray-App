using System.Collections.Generic;
using Player;

public static class GlobalManager
{
    public const int MaxHeight = 150;

    public static bool DebugMode = true;
    public static int Rows = 5;
    public static int Cols = 5;

    public static List<Pin> Pins;
    public static List<Wall> Walls;
}

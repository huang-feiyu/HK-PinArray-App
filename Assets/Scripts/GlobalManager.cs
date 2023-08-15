using System.Collections.Generic;
using Player;

public static class GlobalManager
{
    public const int MaxHeight = 150;

    public static bool DebugMode = true;
    public static int Rows = 2;
    public static int Cols = 2;

    public static List<Pin> Pins;
    public static List<Wall> Walls;

    public const int CubeSize = (int)(25 * 1.2);
    public const int PinSize = 40;
}

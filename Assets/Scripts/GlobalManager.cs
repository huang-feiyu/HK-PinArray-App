using System.Collections.Generic;
using Player;

public static class GlobalManager
{
    public const int MaxHeight = 200;

    public static bool DebugMode = true;
    public static int Rows = 1;
    public static int Cols = 1;

    public static List<int> IArray;

    public static List<Pin> Pins;
    public static List<Wall> Walls;

    public const int CubeSize = (int)(25 * 1.2);
    public const int PinSize = 40;

    public static bool Dragging = false;

    public static bool Waving = false;

    public static bool IsBenchmark = false;
}

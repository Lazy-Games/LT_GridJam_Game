using System;

[Serializable]
public struct HexCoord
{
    public int q;
    public int r;
    public int s;

    public HexCoord(int q = 0, int r = 0, int s = 0)
    {
        this.q = q;
        this.r = r;
        this.s = s;
    }
}
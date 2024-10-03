namespace RGINPO_WPF;

public class Rectangle
{
    public Data LeftBottom { get; set; }
    public Data RightTop { get; set; }

    public double Width => RightTop.X - LeftBottom.X;

    public double Height => RightTop.Y - LeftBottom.Y;

    public Rectangle(Data pointLeftBottom, Data pointRightTop)
    {
        LeftBottom = pointLeftBottom;
        RightTop = pointRightTop;
    }
}
using System.Security.Policy;

namespace SimplePainterApplication;

public enum ShapeType
{
    Ellipse,
    Rect,
    Freehand,
}

[Serializable]
public class Shape
{
    public Color StrokeColor;
    public float StrokeThickness;
    public float X;
    public float Y;
    public float Width;
    public float Height;
    public Color FillColor;
    public bool Filled;
    public ShapeType Type;
    public List<PointF> FreehandPoints; // new property for freehand drawing
    public bool Selected { get; set; }

    public Shape()
    {
        FreehandPoints = new List<PointF>();
    }

    public bool Contains(PointF point)
{
    if (point.X >= X && point.X <= X + Width &&
        point.Y >= Y && point.Y <= Y + Height)
    {
        return true;
    }
    return false;
}


}

using TP3.Paints;

namespace TP3.Repository;

public class PaintRepository
{
    public List<Paint> Paints { get; set; }

    public PaintRepository()
    {
        Paints = new List<Paint>();
    }

    public List<Paint> GetPaintName(string name)
    {
        return Paints.FindAll(paint => paint.Name.Contains(name));
    }

    public void InsertPaint(Paint newPaint)
    {
        Paints.Add(newPaint);
    }
}
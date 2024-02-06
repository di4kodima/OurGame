public class GridCell
{
    string _type;
    public string type { get { return _type; } }
    float centerX, centerY;
    public bool IsOccupied;
    
    public GridCell(string type, float centerX, float centerY, bool IsOccupied)
    {
        _type = type;
        this.centerX = centerX;
        this.centerY = centerY;
        this.IsOccupied = IsOccupied;
    }
}

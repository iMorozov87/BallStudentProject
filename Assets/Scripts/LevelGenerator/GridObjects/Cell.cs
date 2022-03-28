
public class Cell : GridObject
{
    private CellItem _cellItem;

    public CellItem CellItem => _cellItem;

    public void SetCellObject(CellItem cellItem)
    {        
        _cellItem = cellItem;   
    }
}
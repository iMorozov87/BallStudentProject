using UnityEngine;

public class CellItem : GridObject
{
    [SerializeField] private CellItemType _type;
    [Range(0, 100), SerializeField] private int _chance;

    public int Chance => _chance;
    public CellItemType Type => _type;
}

public enum CellItemType
{
    Enemy,
    Bonus
}



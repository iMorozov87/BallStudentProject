using UnityEngine;

public class CellItemTemplates : MonoBehaviour
{
    [SerializeField] CellItem[] _cellItems;

    public bool TryGetRandomItem(out CellItem randomItem)
    {
        randomItem = null;
        foreach (var cellItem in _cellItems)
        {
            if(Random.Range(0,100) <= cellItem.Chance)
            {
                randomItem = cellItem;
                return true;
            }
        }
        return false;
    }
}

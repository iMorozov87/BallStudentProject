using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private Cell _cellTemplate;
    [SerializeField] private CellItemTemplates _cellItems;
    [SerializeField] private float _positionAxisY = -0.2f;
    [SerializeField] private GridObjectsPool _gridObjectsPool;

    private Dictionary<Vector3Int, Cell> _cellsPositions = new Dictionary<Vector3Int, Cell>();

    public void Init()
    {
        _gridObjectsPool.Init();
    }

    public Cell SetFreeCell(Vector3Int gridPosition)
    {
        Cell cell = _gridObjectsPool.GetCell(_cellTemplate);
        cell.gameObject.SetActive(true);
        SetCellPosition(gridPosition, cell);
        _cellsPositions.Add(gridPosition, cell);
        return cell;
    }

    public bool ContentCell(Vector3 worldCentrePosition, int cellFromCenterNumber, out Vector3Int cellPosition)
    {
        Vector3Int gridCentrePosition = WorldToGridPosition(new Vector3(worldCentrePosition.x, _positionAxisY, worldCentrePosition.z));
        cellPosition = new Vector3Int(gridCentrePosition.x + cellFromCenterNumber, gridCentrePosition.y, gridCentrePosition.z);
        return _cellsPositions.ContainsKey(cellPosition);
    }

    public int GetCellCount(float radius)
    {
        return (int)(radius / _cellTemplate.Size);
    }

    public void TrySetCellItem(Cell cell, Vector3Int gridPosition)
    {
        if (_cellItems.TryGetRandomItem(out CellItem randomItem))
        {
            if (randomItem is Enemy && IsCellsContainObstacles(gridPosition) == true)
            {
                return;
            }
            SetCellItem(cell, randomItem);
        }
    }

    private bool IsCellsContainObstacles(Vector3Int gridPosition)
    {
        int checkingCellCount = 3;
        for (int i = 1; i <= checkingCellCount; i++)
        {
            Vector3Int targetPosition = new Vector3Int(gridPosition.x - i, gridPosition.y, gridPosition.z);
            if (_cellsPositions.TryGetValue(targetPosition, out Cell targetCell))
            {
                if (targetCell.CellItem != null && targetCell.CellItem is Enemy)
                {
                    return true;
                }
            }
        }  
        return false;
    }

    private void SetCellItem(Cell cell, CellItem randomItem)
    {
        CellItem cellItem = _gridObjectsPool.GetCellItem(randomItem);
        cellItem.gameObject.SetActive(true);
        cellItem.transform.position = cell.transform.position + Vector3.up * cell.Size;
        cell.SetCellObject(cellItem);
    }

    private void SetCellPosition(Vector3Int gridPosition, Cell cell)
    {
        Vector3 wordPosition = GridToWorldPosition(gridPosition);
        Vector3 spawnPosition = new Vector3(wordPosition.x, _positionAxisY, wordPosition.z);
        cell.transform.position = spawnPosition;  
    }

    private Vector3Int WorldToGridPosition(Vector3 position)
    {
        return new Vector3Int((int)(position.x / _cellTemplate.Size),
                              (int)(position.y / _cellTemplate.Size),
                              (int)(position.z / _cellTemplate.Size));
    }

    private Vector3 GridToWorldPosition(Vector3Int position)
    {
        return (Vector3)position * _cellTemplate.Size;
    }
}

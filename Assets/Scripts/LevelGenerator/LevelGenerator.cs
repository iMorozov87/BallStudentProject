using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelGrid _grid;
    [SerializeField] private Ball _ball;
    [SerializeField] private float _viewingRadius;

    private void Start()
    {
        _grid.Init();
        TryGenerateGrid(CreateFreeCell);
    }

    private void Update()
    {
        TryGenerateGrid(CreateCellAndItem);
    }

    private void TryGenerateGrid(Action<Vector3Int> Fill)
    {
        int cellCount = _grid.GetCellCount(_viewingRadius);

        for (int x = -cellCount; x < cellCount; x++)
        {
            bool isContentCell = _grid.ContentCell(_ball.transform.position, x, out Vector3Int cellInGridPosition);
            if (isContentCell == false)
            {
                Fill(cellInGridPosition);             
            }
        }
    }  

    private void CreateFreeCell(Vector3Int position)
    {
        _grid.SetFreeCell(position);
    }

    private void CreateCellAndItem(Vector3Int position)
    {
        Cell cell = _grid.SetFreeCell(position);
        _grid.TrySetCellItem(cell, position);
    }
}
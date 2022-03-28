using System;
using System.Collections.Generic;
using UnityEngine;

public class GridObjectsPool : MonoBehaviour
{
    [SerializeField] private GridObjectsGroup[] _gridObjectsGroups;
    [SerializeField] private Transform _conteiner;

    private List<GridObject> _gridObjects;

    public void Init()
    {
        _gridObjects = new List<GridObject>();
        foreach (var group in _gridObjectsGroups)
        {
            for (int i = 0; i < group.Count; i++)
            {
                AddGridObject(group.GridObjectTemplate);
            }
        }
    }

    private T AddGridObject<T>(T gridObjectTemplate) where T : GridObject
    {
        T gridObject = Spawn(gridObjectTemplate);
        gridObject.gameObject.SetActive(false);
        _gridObjects.Add(gridObject);
        return gridObject;
    }

    public Cell GetCell(Cell cell)
    {
        return GetGridObject(cell);
    }

    public CellItem GetCellItem(CellItem cellItem)
    {
        return GetGridObject(cellItem);
    }

    public T GetGridObject<T>(T cellItem) where T : GridObject
    {
        if (TryGetGridObject(cellItem, out T gridObject) == true)
        {
            return gridObject;
        }
        return AddGridObject(cellItem);
        throw new NotImplementedException();
    }

    private bool TryGetGridObject<T>(GridObject targetObject, out T gridObject) where T : GridObject
    {
        gridObject = null;
        foreach (var currentObject in _gridObjects)
        {
            if (currentObject.GetType() == targetObject.GetType() && currentObject.gameObject.activeSelf == false)
            {
                gridObject = (T)currentObject;
                return true;
            }
        }
        return false;
    }

    private T Spawn<T>(T gridObjectTemplate) where T : GridObject
    {
        T gridObjects = Instantiate(gridObjectTemplate, _conteiner);
        return gridObjects;
    }

    [System.Serializable]
    class GridObjectsGroup
    {
        public GridObject GridObjectTemplate;
        public int Count;
    }
}


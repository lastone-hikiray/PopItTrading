using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CellsDataContainer")]
public class CellsDataContainer : ScriptableObject 
{
    [SerializeField] private List<int> cellitemsCount;
    public int SavedCellsCount => cellitemsCount.Count;
    public void Init(int listLenght)
    {
        for (int i = 0; i < listLenght; i++)
        {
            cellitemsCount.Add(default);
        }
    }

    public void LoadCellItemsCount(int cellID,out int count)
    {
        count = cellitemsCount[cellID];
    }

    public void SaveCellItemsCount(int cellID, int count)
    {
        cellitemsCount[cellID] = count;
    }
}

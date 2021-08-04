using UnityEngine;


//This script is used only in edit mode
public class InventoryLoader : MonoBehaviour
{
    [Header("Need a link")]
    [SerializeField] private Cell cellTamplate;
    [SerializeField] private GameObject container;
    [SerializeField] private TradeItemSpawner itemsSpawner;
    [SerializeField] private CellsDataContainer cellsData;

    [SerializeField] private Sprite[] icons;
    [SerializeField] private TradeItem[] tradeItems;
    public void Apply()
    {
        int cellsToSpawnCount = icons.Length;
        if (icons.Length != cellsToSpawnCount || tradeItems.Length != cellsToSpawnCount)
        {
            Debug.LogError("Icons and TradeItems are not the same amount \n unable to create invetory cells");
            return;
        }

        if (cellsData.SavedCellsCount != cellsToSpawnCount)
        {
            cellsData.Init(cellsToSpawnCount);
        }

        for (int i = 0; i < cellsToSpawnCount; i++)
        {
            Cell newCell = Instantiate(cellTamplate, container.transform);
            newCell.EditorInit(tradeItems[i], icons[i], itemsSpawner, cellsData,i);
        }
    }

    public void Clear()
    {
        while (container.transform.childCount > 0)
        {
            DestroyImmediate(container.transform.GetChild(0).gameObject);
        }
    }
}


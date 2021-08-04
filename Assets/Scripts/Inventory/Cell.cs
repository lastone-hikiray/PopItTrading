using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [Header("Need a link from inspector")]
    [SerializeField] private Button cellButton;
    [SerializeField] private Image icon;
    [SerializeField] private Text inStockCounter;

    [Header("Link will be added via code")]
    [SerializeField] private int cellID;
    [SerializeField] private TradeItemSpawner itemsSpawner;
    [SerializeField] private TradeItem TradeItemPrefab;
    [SerializeField] private CellsDataContainer cellData;
    [SerializeField] private int itemsInStock;

    //this method calling only in edit mode when is pressed reset Button on InventoryLoader
    public void EditorInit(TradeItem prefab, Sprite sprite, TradeItemSpawner itemsSpawner, CellsDataContainer cellData, int cellID)
    {
        TradeItemPrefab = prefab;
        icon.sprite = sprite;
        this.itemsSpawner = itemsSpawner;
        this.cellData = cellData;
        this.cellID = cellID;
        LoadCellData();
        UpdateCellUI();
    }

    //I put the Find because it doesn't care about performance in the editor, and it's more convenient than drag and drop links manually
    private void Reset()
    {
        cellButton = GetComponentInChildren<Button>();
        icon = transform.Find("Icon").GetComponent<Image>();
    }
    private void OnEnable()
    {
        cellButton.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        cellButton.onClick.RemoveListener(OnButtonClick);
    }
    private void OnButtonClick()
    {
        TrySpawnItem();
    }
    private bool TrySpawnItem()
    {
        if (itemsInStock > 0)
        {
            itemsSpawner.SpawnItem(TradeItemPrefab);
            itemsInStock--;
            UpdateCellUI();
            return true;
        }
        return false;
    }

    public void LoadCellData()
    {
        cellData.LoadCellItemsCount(cellID, out itemsInStock);
    }
    public void SaveCellData()
    {
        cellData.SaveCellItemsCount(cellID, itemsInStock);
    }
    public void UpdateCellUI()
    {
        inStockCounter.text = itemsInStock.ToString();
    }
}

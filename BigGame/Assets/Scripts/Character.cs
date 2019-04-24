using System;
using CharacterStats;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Class ClassCharacter;

    [Header("Weapon Stats/Info")]
    public CharacterStat WeaponDamage;
    public CharacterStat WeaponFireRate;
    public CharacterStat WeaponRange;
    public CharacterStat ProjectileSpeed;
    public Sprite ProjectileSprite;

    [Header("Player Stats")]
    public CharacterStat Health;
    public CharacterStat Mana;
    public CharacterStat Defence;
    public CharacterStat Strength;
    public CharacterStat Dexterity;
    public CharacterStat Wisdom;
    public CharacterStat Vitality;
    public CharacterStat Agility;

    [Header("Public")]
    public Inventory Inventory;
    public EquipmentPanel EquipmentPanel;
    public TalentContainer TalentTree;
    public StatPanel statPanel;

    [Header("Serialize Field")]
    [SerializeField] ItemToolTip itemToolTip;
    //[SerializeField] TalentTooltip talentTooltip;
    [SerializeField] Image draggableItem;

    private BaseItemSlot dragItemSlot;

    public bool containerIsOpen = false;

    private void OnValidate()
    {
        if (itemToolTip == null)
            itemToolTip = FindObjectOfType<ItemToolTip>();
    }

    private void Awake()
    {
        statPanel.SetStats(WeaponDamage, Defence, Strength, Dexterity, Wisdom, Vitality, Agility);
        statPanel.UpdateStatValues();

        // Setup Events:
        // Right Click
        Inventory.OnRightClickEvent += InventoryRightClick;
        EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;
        // Pointer Enter
        Inventory.OnPointerEnterEvent += ShowTooltip;
        EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
        // Pointer Exit
        Inventory.OnPointerExitEvent += HideTooltip;
        EquipmentPanel.OnPointerExitEvent += HideTooltip;
        // Begin Drag
        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        // Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        // Drop
        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        //Talent Tree
        
        TalentTree.OnLeftClickEvent += TalentLeftClick;
        TalentTree.OnRightClickEvent += TalentRightClick;
        /*
        TalentTree.OnPointerEnterEvent += ShowTalentTooltip;
        TalentTree.OnPointerEnterEvent += HideTalentTooltip;
        */
        
    }
    
    private void TalentLeftClick(TalentSlot talentSlot)
    {
        if (talentSlot.CanSelectTalent(talentSlot))
        {
            talentSlot.AddTalent(this);
        }
        statPanel.UpdateStatValues();
    }

    private void TalentRightClick(TalentSlot talentSlot)
    {
        if (talentSlot.CanRemoveTalent(talentSlot))
        {
            talentSlot.RemoveTalent(this);
        }
        statPanel.UpdateStatValues();
    }

    /*
    private void ShowTalentTooltip(TalentSlot talentSlot)
    {
        if (talentSlot.Talent != null)
        {
            //talentTooltip.ShowTooltip(talentSlot.Talent);
        }
    }

    private void HideTalentTooltip(TalentSlot talentSlot)
    {
        if (talentSlot.Talent != null)
        {
            //talentTooltip.HideTooltip(talentSlot.Talent);
        }
    }
    */
    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Equip((EquippableItem)itemSlot.Item);
        }
        
        else if (itemSlot.Item is UsableItem)
        {
            UsableItem usableItem = (UsableItem)itemSlot.Item;
            usableItem.Use(this);

            if (usableItem.IsConsumable)
            {
                Inventory.RemoveItem(usableItem);
                usableItem.Destroy();
            }
        }
    }

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Unequip((EquippableItem)itemSlot.Item);
        }
    }

    private void ShowTooltip(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            itemToolTip.ShowTooltip(itemSlot.Item);
        }
    }

    private void HideTooltip(BaseItemSlot itemSlot)
    {
        if (itemToolTip.gameObject.activeSelf)
        {
            itemToolTip.HideTooltip();
        }
    }

    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }

    private void EndDrag(BaseItemSlot itemSlot)
    {
        //dragItemSlot.image.enabled = true;
        dragItemSlot = null;
        draggableItem.gameObject.SetActive(false);
    }

    private void Drag(BaseItemSlot itemSlot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }

    private void Drop(BaseItemSlot dropItemSlot)
    {
        if (dragItemSlot == null) return;

        if (dropItemSlot.CanAddStack(dragItemSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
    }

    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        EquippableItem dragEquipItem = dragItemSlot.Item as EquippableItem;
        EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

        if (dragItemSlot is EquipmentSlot)
        {
            if (dragEquipItem != null) dragEquipItem.Unequip(this);
            if (dropEquipItem != null) dropEquipItem.Equip(this);
        }
        if (dropItemSlot is EquipmentSlot)
        {
            if (dragEquipItem != null) dragEquipItem.Equip(this);
            if (dropEquipItem != null) dropEquipItem.Unequip(this);
        }
        statPanel.UpdateStatValues();

        Item draggedItem = dragItemSlot.Item;
        int draggedItemAmount = dragItemSlot.Amount;

        dragItemSlot.Item = dropItemSlot.Item;
        dragItemSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    public void Equip(EquippableItem item)
    {
        if (Inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (EquipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    Inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                Inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            Inventory.AddItem(item);
        }
    }

    private ItemContainer openItemContainer;

    private void TransferToItemContainer(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if (item != null && openItemContainer.CanAddItem(item))
        {
            Inventory.RemoveItem(item);
            openItemContainer.AddItem(item);
        }
    }

    private void TransferToInventory(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if (item != null && Inventory.CanAddItem(item))
        {
            openItemContainer.RemoveItem(item);
            Inventory.AddItem(item);
        }
    }

    public void OpenItemContainer(ItemContainer itemContainer)
    {
        openItemContainer = itemContainer;
        containerIsOpen = true;
        Inventory.gameObject.SetActive(true);

        Inventory.OnRightClickEvent -= InventoryRightClick;
        Inventory.OnRightClickEvent += TransferToItemContainer;

        itemContainer.OnRightClickEvent += TransferToInventory;

        itemContainer.OnPointerEnterEvent += ShowTooltip;
        itemContainer.OnPointerExitEvent += HideTooltip;
        itemContainer.OnBeginDragEvent += BeginDrag;
        itemContainer.OnEndDragEvent += EndDrag;
        itemContainer.OnDragEvent += Drag;
        itemContainer.OnDropEvent += Drop;
    }

    public void CloseItemContainer(ItemContainer itemContainer)
    {
        openItemContainer = null;
        containerIsOpen = false;
        Inventory.gameObject.SetActive(false);

        Inventory.OnRightClickEvent += InventoryRightClick;
        Inventory.OnRightClickEvent -= TransferToItemContainer;

        itemContainer.OnRightClickEvent -= TransferToInventory;

        itemContainer.OnPointerEnterEvent -= ShowTooltip;
        itemContainer.OnPointerExitEvent -= HideTooltip;
        itemContainer.OnBeginDragEvent -= BeginDrag;
        itemContainer.OnEndDragEvent -= EndDrag;
        itemContainer.OnDragEvent -= Drag;
        itemContainer.OnDropEvent -= Drop;
    }

    public void UpdateStatValues()
    {
        statPanel.UpdateStatValues();
    }
}
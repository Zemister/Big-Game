using CharacterStats;
using UnityEngine;
using UnityEngine.UI;

public enum ClassCharacter
{
    class1,
    class2,
    class3,
    class4,
    class5,
    class6,
    noclass,
}

public class Character : MonoBehaviour
{
    public ClassCharacter ClassCharacter;
    public CharacterStat WeaponDamage;
    public CharacterStat WeaponFireRate;

    public CharacterStat Health;
    public CharacterStat Mana;
    public CharacterStat Defence;
    public CharacterStat Strength;
    public CharacterStat Dexterity;
    public CharacterStat Wisdom;
    public CharacterStat Vitality;
    public CharacterStat Agility;

    [SerializeField] private Inventory inventory;
    [SerializeField] private EquipmentPanel equipmentPanel;
    [SerializeField] private StatPanel statPanel;
    [SerializeField] private ItemToolTip itemToolTip;
    [SerializeField] private Image draggableItem;

    private ItemSlot draggedSlot;

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
        //Right Click
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        //Pointer Enter
        inventory.OnPointerEnterEvent += ShowTooltip;
        equipmentPanel.OnPointerEnterEvent += ShowTooltip;
        //Pointer Exit
        inventory.OnPointerExitEvent += HideTooltip;
        equipmentPanel.OnPointerExitEvent += HideTooltip;
        //Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        //End Drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        //Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        //Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
    }

    private void Equip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    private void ShowTooltip(ItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            itemToolTip.ShowTooltip(equippableItem);
        }
        /* changes to test
        if (itemSlot.Item != null)
		{
			itemTooltip.ShowTooltip(itemSlot.Item);
		}
         */
    }

    private void HideTooltip(ItemSlot itemSlot)
    {
        itemToolTip.HideTooltip();
    }

    private void BeginDrag(ItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true); //Try this draggableItem.gameObject.SetActive(true);
            //draggedSlot.image.enabled = false;
        }
    }

    private void EndDrag(ItemSlot itemSlot)
    {
        //draggedSlot.image.enabled = true;
        draggedSlot = null;
        draggableItem.gameObject.SetActive(false);
    }

    private void Drag(ItemSlot itemSlot)
    {
            draggableItem.transform.position = Input.mousePosition;
    }

    private void Drop(ItemSlot dropItemSlot)
    {
        if (draggedSlot == null) return;

        if (dropItemSlot.CanRecieveItem(draggedSlot.Item) && draggedSlot.CanRecieveItem(dropItemSlot.Item))
        {
            EquippableItem dragItem = draggedSlot.Item as EquippableItem;
            EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

            if (draggedSlot is EquipmentSlot)
            {
                if (dragItem != null) dragItem.Unequip(this);
                if (dropItem != null) dropItem.Equip(this);
                //draggedSlot.image.enabled = true;
            }
            if (dropItemSlot is EquipmentSlot)
            {
                if (dragItem != null) dragItem.Equip(this);
                if (dropItem != null) dropItem.Unequip(this);
            }
            statPanel.UpdateStatValues();

            Item draggedItem = draggedSlot.Item;
            int draggedItemAmount = draggedSlot.Amount;

            draggedSlot.Item = dropItemSlot.Item;
            draggedSlot.Amount = dropItemSlot.Amount;

            dropItemSlot.Item = draggedItem;
            dropItemSlot.Amount = draggedItemAmount;
        }
    }

    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                statPanel.UpdateStatValues();
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            statPanel.UpdateStatValues();
            inventory.AddItem(item);
        }
    }
}
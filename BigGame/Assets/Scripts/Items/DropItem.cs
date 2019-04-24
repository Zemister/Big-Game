using UnityEngine;

public class DropItem : MonoBehaviour //drop item needs to decide what item it is based on the enemy's list of droppable items, have inventory, and sprite renderer that changes according to item that drops
{
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode itemPickupKeycode = KeyCode.T;

    private bool isInRange;

    public int _amount;
    public Item _item;

    private void Start()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Character>().Inventory;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CreateDropItem(Item item, int amount, Vector3 position)
    {
        _item = item;
        _amount = amount;
        spriteRenderer.sprite = item.icon;
        Instantiate(this, position, Quaternion.identity);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickupKeycode))
        {
            Item itemCopy = _item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                _amount--;
                if (_amount == 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                itemCopy.Destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CheckCollision(other.gameObject, false);
    }

    private void CheckCollision(GameObject gameObject, bool state)
    {
        if (gameObject.gameObject.CompareTag("Player") && _amount > 0)
        {
            isInRange = state;
        }
    }
}

using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] int amount = 1;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode itemPickupKeycode = KeyCode.T;

    private bool isInRange;

    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = item.icon;
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(itemPickupKeycode))
        {
            Item itemCopy = item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    item = null;
                    spriteRenderer.enabled = false;
                }
            } else
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
        if (gameObject.gameObject.CompareTag("Player"))
        {
            isInRange = state;
            spriteRenderer.enabled = state;
        }
    }
}
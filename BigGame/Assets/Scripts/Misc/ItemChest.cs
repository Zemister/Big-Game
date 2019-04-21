using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] int amount = 1;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] KeyCode itemPickupKeycode = KeyCode.T;

    private bool isInRange;
    private bool isEmpty;

    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = item.icon;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (isInRange && !isEmpty && Input.GetKeyDown(itemPickupKeycode))
        {
            Item itemCopy = item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    isEmpty = true;
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
        if (gameObject.gameObject.CompareTag("Player") && amount > 0)
        {
            isInRange = state;
            spriteRenderer.enabled = state;
        }
    }
}
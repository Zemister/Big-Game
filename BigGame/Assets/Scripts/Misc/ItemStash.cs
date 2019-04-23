using UnityEngine;

public class ItemStash : ItemContainer
{
    [SerializeField] protected Transform itemsParent;
    [SerializeField] KeyCode openKeyCode = KeyCode.I;

    private bool isOpen;
    private bool isInRange;

    private Character character;

    protected override void OnValidate()
    {
        if(itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);
    }

    protected override void Awake()
    {
        base.Awake();
        itemsParent.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(openKeyCode)) {
            isOpen = !isOpen;
            itemsParent.gameObject.SetActive(isOpen);

            if (isOpen)
                character.OpenItemContainer(this);
            else
                character.CloseItemContainer(this);
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

            if(!isInRange && isOpen)
            {
                isOpen = false;
                itemsParent.gameObject.SetActive(isOpen);
                character.CloseItemContainer(this);
            }

            if (isInRange)
                character = gameObject.GetComponent<Character>();
            else
                character = null;
        }
    }
}
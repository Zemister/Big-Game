using UnityEngine;

public class CursorEditor : MonoBehaviour
{
    [SerializeField] Texture2D[] cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
       Cursor.SetCursor(cursorTexture[0], hotSpot, cursorMode);
    }
}

using UnityEngine;

public class StatsInput : MonoBehaviour
{
    [SerializeField] GameObject statsGameObject;
    [SerializeField] StatToolTip statToolTip;
    [SerializeField] KeyCode[] toggleInventoryKeys;

    private void Update()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                statsGameObject.SetActive(!statsGameObject.activeSelf);
                statToolTip.HideTooltip();
                break;
            }
        }
    }
}

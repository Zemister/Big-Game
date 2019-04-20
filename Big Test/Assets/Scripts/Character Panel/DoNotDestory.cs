using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestory : MonoBehaviour
{
    private static bool canvasExists;

    void Start()
    {
        if (!canvasExists)
        {
            canvasExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

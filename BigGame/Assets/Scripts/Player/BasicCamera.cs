using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamera : MonoBehaviour {

    public GameObject target;
    public Vector3 offset = new Vector3(0, 0, -1);

    private static bool objectExists;

    private void Start()
    {
        if(!objectExists)
        {
            objectExists = true;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    void Update () {
		if (target)
        {
            transform.position = new Vector3(
                target.transform.position.x + offset.x,
                target.transform.position.y + offset.y,
                target.transform.position.z + offset.z);
        }
	}
}

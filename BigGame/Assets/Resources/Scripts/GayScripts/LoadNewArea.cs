using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitPoint;

    PlayerController thePlayer;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
   /*private static Transform[] allObjects;

   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.name == "Player")
       {
           allObjects = FindObjectsOfType(typeof(Transform)) as Transform[];
           foreach (Transform t in allObjects)
           {
               var playerScript = t.GetComponent<PlayerController>();
               var cameraScript = t.GetComponent<CameraController>();
               if (playerScript == null && cameraScript == null)
               {
                   Destroy(t.gameObject);
               }
           }
           SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);
       }
   }
}*/

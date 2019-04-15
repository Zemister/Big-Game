using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;
    
    /*
    public void TaskOnClick(string sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
    }
    */
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}

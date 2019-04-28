using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public void LoadArea(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}

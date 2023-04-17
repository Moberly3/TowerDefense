using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public string sceneName = "Demo";

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

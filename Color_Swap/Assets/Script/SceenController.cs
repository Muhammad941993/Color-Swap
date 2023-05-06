using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenController : MonoBehaviour
{
    int sceenNumber;
    private void Start()
    {
        sceenNumber = SceneManager.sceneCountInBuildSettings;
    }
    public void LoadNextLevel()
    {
        int x = SceneManager.GetActiveScene().buildIndex +1;

        if (x >= sceenNumber) x = 0;
       
        SceneManager.LoadScene(x);
    }

   
}

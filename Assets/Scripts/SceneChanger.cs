using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
    public void NextScene() {
        if (SceneManager.GetActiveScene().buildIndex+1 == SceneManager.sceneCountInBuildSettings) {
            SceneManager.LoadScene(0);
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}

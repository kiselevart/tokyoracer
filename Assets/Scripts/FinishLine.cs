using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lapText;
    [SerializeField] Timer timer;
    float time;
    public int lap;

    void Start() {
        lap = 1;
        lapText.text = string.Format("LAP: 1/3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lap == 3) {
                PlayerPrefs.SetFloat("LatestTime", timer.elapsedTime);
                PlayerPrefs.Save();

                Debug.Log("CHANGING SCENE");
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
                SceneManager.LoadScene(nextSceneIndex);
            }
            else {
                lap = lap + 1;
                lapText.text = string.Format("LAP: {0}/3", lap);
            }
        }
    }
}

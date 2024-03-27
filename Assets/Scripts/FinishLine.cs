using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lapText;
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
                SceneManager.LoadScene("Scores");
            }
            else {
                lap = lap + 1;
                lapText.text = string.Format("LAP: {0}/3", lap);
            }
        }
    }
}

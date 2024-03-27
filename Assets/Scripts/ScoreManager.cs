using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSaver : MonoBehaviour
{
    public void LevelCompleted(float completionTime) {
        PlayerPrefs.SetFloat("LevelCompletionTime", completionTime);
        PlayerPrefs.Save();
    }
}

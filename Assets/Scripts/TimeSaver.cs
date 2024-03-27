using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public void LevelCompleted(float completionTime) {
        PlayerPrefs.SetFloat("LevelCompletionTime", completionTime);
        PlayerPrefs.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI leaderboardText; 

    void Start() {
        DisplayLeaderboard();
    }

    void DisplayLeaderboard() {
        float completionTime = PlayerPrefs.GetFloat("LevelCompletionTime");
        leaderboardText.text = "Completion Time: " + completionTime.ToString("F2");
    }
}

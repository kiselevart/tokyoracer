using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI latestTimeText;
    void Start()
    {
        float time = PlayerPrefs.GetFloat("LatestTime", 0);
        float rounded = (float)Math.Round(time, 2);
        string score = string.Format("TIME: {0}", rounded.ToString());
        latestTimeText.text = score; 
    }
}

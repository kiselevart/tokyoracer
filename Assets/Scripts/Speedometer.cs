using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject car;
    [SerializeField] TextMeshProUGUI speedText; 
    public float speed;

    void Awake() {
        car = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        speed = car.GetComponent<WheelController>().getSpeed();
        speed = speed * 14;
        speed = Mathf.RoundToInt(speed);
        speedText.text = speed.ToString();
    }
}


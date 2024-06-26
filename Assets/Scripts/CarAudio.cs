using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    public AudioSource runningSound;
    public float runningMaxVolume;
    public float runningMaxPitch;
    public AudioSource reverseSound;
    public float reverseMaxVolume;
    public float reverseMaxPitch;
    public AudioSource idleSound;
    public float idleMaxVolume;
    public float speedRatio;
    private float revLimiter;
    public float LimiterSound = 1f;
    public float LimiterFrequency = 3f;
    public float LimiterEngage = 0.8f;
    public bool isEngineRunning = false;

    public AudioSource startingSound;


    private WheelController carController;
    // Start is called before the first frame update
    void Start()
    {
        idleSound.volume = 0;
        runningSound.volume = 0;
        reverseSound.volume = 0;
        carController = GetComponent<WheelController>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedSign=0;
        if (carController)
        {
            speedSign = Mathf.Sign(carController.getSpeedRatio());
            speedRatio = Mathf.Abs(carController.getSpeedRatio());
        }
        if (speedRatio > LimiterEngage)
        {
            revLimiter = (Mathf.Sin(Time.time * LimiterFrequency) + 1f) * LimiterSound * (speedRatio - LimiterEngage);
        }
        if (isEngineRunning)
        {
            idleSound.volume = Mathf.Lerp(0.1f, idleMaxVolume, speedRatio);
            if (speedSign > 0)
            {
                reverseSound.volume = 0;
                runningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);
                runningSound.pitch = Mathf.Lerp(runningSound.pitch, Mathf.Lerp(0.3f, runningMaxPitch, speedRatio) + revLimiter, Time.deltaTime);
            }
            else
            {
                runningSound.volume = 0;
                reverseSound.volume = Mathf.Lerp(0f, reverseMaxVolume, speedRatio);
                reverseSound.pitch = Mathf.Lerp(reverseSound.pitch, Mathf.Lerp(0.2f, reverseMaxPitch, speedRatio) + revLimiter, Time.deltaTime);
            }
        }
        else {
            idleSound.volume = 0;
            runningSound.volume = 0;
        }
    }

    public IEnumerator StartEngine()
    {
        startingSound.Play();
        yield return new WaitForSeconds(0.6f);
        isEngineRunning = true;
        yield return new WaitForSeconds(0.4f);
    }
}

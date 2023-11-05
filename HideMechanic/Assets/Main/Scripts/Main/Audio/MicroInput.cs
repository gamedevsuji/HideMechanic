using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroInput : MonoBehaviour
{

    public float sensitivity = 100f;
    public float loudness = 0f;

    public float jumpLoudnessThreshold;

    public string selectedDevice;

    AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        //_audio.clip = Microphone.Start(null, true, 10, 44100);
        //_audio.loop = true;
        //_audio.mute = true;

        //while (!(Microphone.GetPosition(null) > 0))
        //{

        //}

        //_audio.Play();


        if(Microphone.devices.Length > 0)
        {
            selectedDevice = Microphone.devices[0].ToString();
            _audio.clip = Microphone.Start(selectedDevice, true,10, AudioSettings.outputSampleRate);
        }
    }

    void Update()
    {
        loudness = GetAverageVolume() * sensitivity;
        Debug.Log(loudness);
        if (loudness > jumpLoudnessThreshold )
        {
            Debug.Log("Loud Music");
        }

    }

    //void FixedUpdate()
    //{
    //    isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    //}

    float GetAverageVolume()
    {

        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);

        foreach (float s in data)
        {
            Debug.Log("Sample "+s.ToString());
            a += Mathf.Abs(s);
        }

        return (a / 256f);
    }

}
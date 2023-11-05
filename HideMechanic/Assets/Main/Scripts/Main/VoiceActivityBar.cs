using UnityEngine;
using UnityEngine.UI;

public class VoiceActivityBar : MonoBehaviour
{
    public float updateSpeedSeconds = 0.1f; // Adjust this for the speed of the bar's response
    public float sensitivity = 100f; // Adjust this for the sensitivity of the voice input

    private Image voiceBar;
    private float currentLevel = 0f;

    [SerializeField]private AudioSource audioSource;

    void Start()
    {
        voiceBar = GetComponent<Image>(); // Assuming this script is attached to the voice activity bar image
    }

    void Update()
    {
        float currentMicLevel = MicrophoneLevel();
        currentLevel = Mathf.Lerp(currentLevel, currentMicLevel, Time.deltaTime / updateSpeedSeconds);
        voiceBar.fillAmount = currentLevel;
    }

    float MicrophoneLevel()
    {
        float levelMax = 0;
        float[] waveData = new float[1024];
        int micPosition = Microphone.GetPosition(null) - (1024 + 1); // null means the first microphone
        if (micPosition > 0)
        {
            audioSource.GetSpectrumData(waveData, 0, FFTWindow.BlackmanHarris);
            for (int i = 0; i < 1024; i++)
            {
                float wavePeak = waveData[i] * sensitivity;
                if (levelMax < wavePeak)
                {
                    levelMax = wavePeak;
                }
            }
        }
        return levelMax;
    }
}
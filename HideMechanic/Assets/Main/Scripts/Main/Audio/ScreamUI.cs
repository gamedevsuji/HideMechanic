using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ScreamUI : MonoBehaviour
{
    [SerializeField]private float minScale;
    [SerializeField]private float maxScale;
    [SerializeField]private MicrophoneInput detector;

    [Range(1,100)]
    [SerializeField] private float loudnessSensiblity = 100f;


    private RectTransform screamRect;

    private Image screamImage;

    [Header("Noise Colour")]

    [SerializeField] private Color normalColor;
    [SerializeField] private Color moderateColor;
    [SerializeField] private Color highColor;

    [Header("Noise Color in Percentage")]
    [Range(1, 100)]
    [SerializeField] private int normalPercent;

    [Range(1, 100)]
    [SerializeField] private int moderatePercent;

    [Range(1, 100)]
    [SerializeField] private int highPercent;

    private float normalThreshold, moderateThreshold, highThreshold;

    private float loudness;


    private void Start()
    {
        screamRect = GetComponent<RectTransform>();

        screamImage = GetComponent<Image>();

        normalThreshold = maxScale * normalPercent / 100;

        moderateThreshold = maxScale * moderatePercent / 100;

        highThreshold = maxScale * highPercent / 100;



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Loudness  " + detector.GetLoudnessFromMicrophone());


        loudness = detector.GetLoudnessFromMicrophone() * loudnessSensiblity;
        //if (loudness < threshold)
        //    loudness = 0;

        Debug.Log("Loudness  " + loudness);

        //screamUIimage.fillAmount = Mathf.Lerp(minScale, maxScale, loudness);

        screamRect.sizeDelta = new Vector2(screamRect.sizeDelta.x, Mathf.Lerp(minScale, maxScale, loudness));

        Debug.Log("SizeDelta " + screamRect.sizeDelta.y);

        if(screamRect.sizeDelta.y <= normalThreshold)
        {
            screamImage.color = normalColor;
        }
        else if(screamRect.sizeDelta.y > normalThreshold && screamRect.sizeDelta.y <= moderateThreshold)
        {

            screamImage.color = moderateColor;
        }
        else if(screamRect.sizeDelta.y > moderateThreshold && screamRect.sizeDelta.y <= highThreshold)
        {

            screamImage.color = highColor;
        }
        else if(screamRect.sizeDelta.y > highThreshold)
        {
            screamImage.color = highColor;

        }



        // transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode]

public class ProgressBar : MonoBehaviour
{
    [Header("Bar Setting")]
    public Color BarColor;
    public Color BarBackGroundColor;
    public Sprite BarBackGroundSprite;
    [Range(1f, 100f)]
    public int Alert = 20;
    public Color BarAlertColor;

    private Image bar, barBackground;
    private float nextPlay;
    private AudioSource audiosource;
    private float barValue;
    private float barMaxValue;
    public float BarValue
    {
        get { return barValue; }

        set
        {
            barValue = value;
            UpdateValue(barValue);
        }
    }

    public float BarMaxValue
    {
        get { return barMaxValue; }
        set
        {
            barMaxValue = value;
        }
    }

    public void InitBar(float currentValue, float maxValue)
    {
        BarMaxValue = maxValue;
        BarValue = currentValue;
    }

    private void Awake()
    {
        bar = transform.Find("Bar").GetComponent<Image>();
        if (barBackground != null)
        {
            barBackground = GetComponent<Image>();
            barBackground = transform.Find("BarBackground").GetComponent<Image>();
        }
    }

    private void Start()
    {
        bar.color = BarColor;
        if (barBackground != null)
        {
            barBackground.color = BarBackGroundColor;
            barBackground.sprite = BarBackGroundSprite;
        }

        UpdateValue(barValue);
    }

    void UpdateValue(float val)
    {
        bar.fillAmount = val / barMaxValue;

        if (Alert >= val)
        {
            bar.color = BarAlertColor;
        }
        else
        {
            bar.color = BarColor;
        }
    }


    private void Update()
    {
        if (!Application.isPlaying)
        {
            bar.color = BarColor;
            if (barBackground != null)
            {
                barBackground.color = BarBackGroundColor;

                barBackground.sprite = BarBackGroundSprite;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMeter : MonoBehaviour
{
    private Slider _slider;
    private Slider slider
    {
        get
        {
            if (_slider == null)
                _slider = GetComponent<Slider>();
            return _slider;
        }
    }

    public RectTransform aimTarget;
    public float initialWidth;
    public float newWidth;
    
    [Range(-0.1f, 1.2f)]
    public float value;

    private void Start()
    {
        initialWidth = aimTarget.rect.width;
    }

    public void Refresh()
    {
        value = 0;
    }

    private void Update()
    {
        slider.value = value;

        if(value >= 1f)
        {
            newWidth = (initialWidth * (1 - value) + initialWidth);
            aimTarget.sizeDelta = new Vector2(newWidth, aimTarget.sizeDelta.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSpeedSlider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Object = gameObject;
        Slider slider = Object.GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);


    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSliderValueChanged(float value)
    {
        TimeTicker.Instance.MaxFPS = (int)value;
        Debug.Log("fff");
    }    
}

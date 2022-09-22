using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderBehaviour : MonoBehaviour
{
   public void OnSliderValueChanged(float value)
    {
        Debug.Log("<<<<<< Slider value is "+ value +" >>>>>");
    }
}

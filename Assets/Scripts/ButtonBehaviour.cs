using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonBehaviour : MonoBehaviour
{
    private int currentVal = 0;
    [SerializeField] private TMP_Text text;

    public void OnButtonPress()
    {
        currentVal++;
        Debug.Log("<<<<<< Button Press Count = "+ currentVal + ">>>>>");
        text.text = "Button Press Count = " + currentVal;      
        // run some code
    }
}

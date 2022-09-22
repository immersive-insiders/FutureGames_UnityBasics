using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleBehaviour : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    public void OnToggle(bool value)
    {
        if(value)
            text.text = "true";
        else
            text.text = "false";

    }
}

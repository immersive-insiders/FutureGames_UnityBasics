using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSomething : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        for (int i = 0;  i< 255;i ++)
        {
            meshRenderer.material.color = new Color(0, 0, 0, i);

        }

        for (int i = 255; i < 0; i--)
        {
            meshRenderer.material.color = new Color(0, 0, 0, i);

        }
    }
}

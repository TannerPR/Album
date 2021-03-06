﻿using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour
{
    // public vars
    public float pulseSize;
    public Vector3 sizeReduceSpeed;

    // public hidden vars
    [HideInInspector]
    public bool pulseActive;

    void Start()
    {
        size = Vector3.zero;
        pulseActive = false;
        originalSize = this.transform.localScale;
    }

    void Update()
    {
        if (pulseActive)
        {
			Debug.Log (this.name + " is pulsing");
            size.x = pulseSize;
            size.y = pulseSize;
            size.z = pulseSize;
            pulseActive = false;
            //}
            this.gameObject.transform.localScale += size;
        }
        else
        {
            if(this.gameObject.transform.localScale.x >= originalSize.x ||
               this.gameObject.transform.localScale.y >= originalSize.y ||
               this.gameObject.transform.localScale.z >= originalSize.z)
            this.gameObject.transform.localScale -= sizeReduceSpeed;
        }
    }


    //private variables
    //GameObject obj;
    Vector3 size;
    Vector3 originalSize;
}
using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour
{
    public bool pulseActive;

    void Start()
    {
        size = Vector3.zero;
        pulseActive = false;
    }

    void Update()
    {
        if (pulseActive)
        {
            //for (int i = 0; i < 60; i++) 
            //{
            // Don't always need a member var for time, just use Time.Time
            //size.x = Mathf.Sin (Time.time) * i / 60;
            //size.y = Mathf.Sin (Time.time) * i / 60;
            //size.z = Mathf.Sin (Time.time) * i / 60;

            size.x = 1;
            size.y = 1;
            size.z = 1;
            pulseActive = false;
            //}
            this.gameObject.transform.localScale += size;
        }
    }

    //private variables
    //GameObject obj;
    Vector3 size;
    float timer;
}
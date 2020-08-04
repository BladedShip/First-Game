using UnityEngine;
using System;
using System.Collections;

public class Bjounce : MonoBehaviour
{
    float PosOriginal;
    public float Strength = 1;
    void Start()
    {
        this.PosOriginal = this.transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, PosOriginal + ((float)Math.Sin(Time.time) * Strength), transform.position.z);
    }
}
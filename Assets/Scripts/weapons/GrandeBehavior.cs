﻿using UnityEngine;

public class GrandeBehavior : MonoBehaviour
{
    public float delay = 3f;
    bool hasExploded = false;
    float countdown;
    public GameObject explotionEffect;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f&&!hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

     void Explode()
    {

        Instantiate(explotionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

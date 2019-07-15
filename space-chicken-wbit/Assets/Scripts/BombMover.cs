﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMover : MonoBehaviour
{
     private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.AddForce(GameControl.instance.BombDirection * 1f);
    }
}

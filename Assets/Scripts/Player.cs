using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;
    public Transform sprite;

    public float speed;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float hMovement = Input.GetAxis("Horizontal");
        float vMovement = Input.GetAxis("Vertical");

        rig.velocity = new Vector2(hMovement * speed, vMovement * speed);
    }
}

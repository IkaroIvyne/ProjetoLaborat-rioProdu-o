using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;
    public Transform player;

    public List<Sprite> sprites;



    public float speed;

    public GameObject spritePlayer;
    public SpriteRenderer _currentSprite;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        _currentSprite = spritePlayer.GetComponent<SpriteRenderer>();
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


        if (vMovement > 0)
        {
            _currentSprite.sprite = sprites[0];
            Debug.Log(vMovement);
        }
         if (vMovement < 0)
        {
            _currentSprite.sprite = sprites[1];
            Debug.Log(vMovement);
        }
        if (hMovement < 0)
        {
            _currentSprite.sprite = sprites[2];
            Debug.Log(hMovement);

        }
         if (hMovement > 0)
        {
            _currentSprite.sprite = sprites[3];
            Debug.Log(hMovement);

        }
    }
}

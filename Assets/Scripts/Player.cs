using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D rig;
    public Animator anim;
    public Transform player;

    public List<Sprite> idleSprites;
    private Sprite _lastIdleSprite;
    private int _lastIndexAnimation; // 0 - Down, 2 - Up , 4 - right and 6 - left



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
            _currentSprite.sprite = idleSprites[0];
            _lastIdleSprite = idleSprites[0];
            _lastIndexAnimation = 2;
            anim.SetInteger("transition", 3);
            Debug.Log(vMovement);
        }
        else if (vMovement < 0)
        {
            _currentSprite.sprite = idleSprites[1];
            _lastIdleSprite = idleSprites[1];
            _lastIndexAnimation = 0;
            anim.SetInteger("transition", 1);
            Debug.Log(vMovement);
        }
        else if (hMovement < 0)
        {
            _currentSprite.sprite = idleSprites[2];
            _lastIdleSprite = idleSprites[2];
            _lastIndexAnimation = 6;
            anim.SetInteger("transition", 7);
            Debug.Log(hMovement);

        }
        else if (hMovement > 0)
        {
            _currentSprite.sprite = idleSprites[3];
            _lastIdleSprite = idleSprites[3];
            _lastIndexAnimation = 4;
            anim.SetInteger("transition", 5);
            Debug.Log(hMovement);

        }
        else
        {
            _currentSprite.sprite = _lastIdleSprite;
            anim.SetInteger("transition", _lastIndexAnimation);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private Rigidbody2D rbody;
    private const float MOVESPEED = 3;
    private float moveSpeed;

    public LayerMask blocklayer;

    public enum MOVE_DIR
    {
        STOP,
        LEFT,
        RIGHT,
    };

    private MOVE_DIR moveDirection = MOVE_DIR.STOP;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void FixedUpdate()
	{
        switch(moveDirection){
            case MOVE_DIR.STOP:
                moveSpeed = 0;
                break;
            case MOVE_DIR.LEFT:
                moveSpeed = MOVESPEED * -1;
                transform.localScale = new Vector2(-1, 1);
                break;
            case MOVE_DIR.RIGHT:
                moveSpeed = MOVESPEED;
                transform.localScale = new Vector2(1, 1);
                break;
        }
        rbody.velocity = new Vector2(moveSpeed, rbody.velocity.y);
	}

    public void PushLeftButton(){
        moveDirection = MOVE_DIR.LEFT;
    }

    public void PushRightButton()
    {
        moveDirection = MOVE_DIR.RIGHT;
    }

    public void ReleaseMoveButton()
    {
        moveDirection = MOVE_DIR.STOP;
    }
}

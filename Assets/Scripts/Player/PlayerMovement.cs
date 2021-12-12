using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask obstaclesLayers;
    
    public InputManager controls;

    private bool lockDirection;
    private bool idle;
    private Vector2 direction;
    private Vector2 lastDirection;

    private Rigidbody2D rigidBody;
    private BoxCollider2D collider;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        controls = new InputManager();
        controls.Player.Right.performed += a => GoRight();
        controls.Player.Left.performed += b => GoLeft();
        controls.Player.Up.performed += c => GoUp();
        controls.Player.Down.performed += d => GoDown();
    }

    private void OnEnable()
    {
        controls.Enable();

    }

    private void OnDisable()
    {
        if (controls!=null) controls.Disable();
        controls.Player.Right.performed -= a => GoRight();
        controls.Player.Left.performed -= b => GoLeft();
        controls.Player.Up.performed -= c => GoUp();
        controls.Player.Down.performed -= d => GoDown();
    }

    private void Start()
    {
        Debug.Log("Start Moving");
        UnlockDirection();
        direction = Vector2.zero;
        lastDirection = direction;
        idle = true;
        rigidBody.freezeRotation = true;
    }
    

    private void FixedUpdate()
    {
        if (idle & direction!=lastDirection)
        {
            
            rigidBody.velocity = direction * speed;
            lastDirection = direction;
            idle = false;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (!idle)
        {
            Vector3 position3D = transform.position;
            Vector2 position = new Vector2(position3D.x, position3D.y);
            Vector3 bounds3D = collider.bounds.size;
            Vector2 size = new Vector2(bounds3D.x, bounds3D.y);
            RaycastHit2D objectAhead = Physics2D.BoxCast(position, size*0.5f, 0f, lastDirection, 0.3f, obstaclesLayers);
            if (objectAhead /*|| rigidBody.velocity.magnitude<0.001f*/)
            {
                Debug.Log("HIT OBSTACLE");
                idle = true;
                //UnlockDirection();
            }
        }
    }

    

    private void LockDirection() => lockDirection = true;
    private void UnlockDirection() => lockDirection = false;
    private void GoDown()=>SetDirection(Vector2.down);
    private void GoUp()=>SetDirection(Vector2.up);
    private void GoLeft()=>SetDirection(Vector2.left);
    private void GoRight() => SetDirection(Vector2.right);
    private void SetDirection(Vector2 _direction)
    {
        if (idle)
        {
            Debug.Log("New direction!");
            direction = _direction;
            if (Mathf.Abs(direction.y)>0.01f) FreezeHorizontal();
            else FreezeVertical();
            
        }
    }

    private void FreezeVertical()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionY;
        rigidBody.freezeRotation = true;
    }

    private void FreezeHorizontal()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezePositionX;
        rigidBody.freezeRotation = true; 
    }
}

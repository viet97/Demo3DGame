using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BasePlayer
{
    public Rigidbody rigidbody;
    private State state;
    // Start is called before the first frame update
    private int maxHealth = 100;
    private int health = 100;
    private int dame = 20;
    public HealthBar healthBar;
    void Start()
    {
       rigidbody = GetComponent<Rigidbody>();
       state = State.Idle;
       healthBar.setHealtPercentage(1f);
    }

    private enum State
    {
        Idle,
        Sliding,
        Busy,
    }
    public Vector3 targetPosition;
    public Player targetPlayer;
    private Action onSlideComplete;

    // Update is called once per frame
    void Update()
    {
    
       
    }
    // fixedUpdate is called once every physic update
    private void FixedUpdate()
    {
        switch (state) {
            case State.Idle:
                break;
            case State.Busy:
                break;
            case State.Sliding:
                transform.position += (targetPosition - GetPosition()) * 5 * Time.deltaTime;

                float reachedDistance = 1f;
                if (Vector3.Distance(GetPosition(), targetPosition) < reachedDistance)
                {

                    this.onSlideComplete();

                }
                break;
        }
        //if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f,playerMask).Length == 0)
        //{
        //    return;
        //}
        //if (jumpKeyWasPressed) {
        //    rigidbody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        //    jumpKeyWasPressed = false;
        //}
        //rigidbody.velocity = new Vector3(horizontalInput, rigidbody.velocity.y, GetComponent<Rigidbody>().velocity.z);
    }

    public void slideToPosition(Vector3 position,Action onSlideComplete)
    {
        state = State.Sliding;
        targetPosition = position;
        this.onSlideComplete = onSlideComplete;
    }

    public void Damage(int dame)
    {
        health -= dame;
        Debug.Log("Height + dame:" + health + ":" + dame);
        if (health < 0) health = 0;
        Debug.Log("Dame:" +health+ ":"+ (float)health / maxHealth);
        healthBar.setHealtPercentage((float)health / maxHealth);
    }

    public void Attack(Vector3 targetPosition,Action<int> onAttackComplete)
    {
        Vector3 startPosition = GetPosition();
        slideToPosition(targetPosition, () => {
            onAttackComplete(dame);
            slideToPosition(startPosition, () =>
                    {
                        state = State.Idle;
                    });
                });
    }
}

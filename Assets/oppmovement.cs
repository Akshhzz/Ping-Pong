using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class oppmovement : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Rigidbody2D rbball;
    public float speed = 8f;
    public logicscript lgc;


    public float aiSpeed = 8f;
    public float reactionTime = 0.15f; // seconds (increase = weaker AI)
    public float deadZone = 0.1f;       // prevents jitter

    private float reactionTimer = 0f;
    private float targetY;
    void Start()
    {
        rb2.linearVelocity = new Vector2(0, 0);
        lgc = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (lgc.isPause == false)
        {

            if (logicscript.istwoplayer == false)
            {
               AImovement();
            }

            else
            {
               player2movment();
            }

        }


        
        //if (lgc.isPause == true)
       // {
        //    rb2.linearVelocity = new Vector2(0, 0);
        //}

    }

    private void AImovement()
    {

        reactionTimer -= Time.fixedDeltaTime;

        if (reactionTimer <= 0f)
        {
            targetY = rbball.position.y;
            reactionTimer = reactionTime;
        }

        float difference = targetY - rb2.position.y;

        if (Mathf.Abs(difference) < deadZone) return;

        float newY = Mathf.MoveTowards(rb2.position.y,targetY,aiSpeed * Time.fixedDeltaTime);
        rb2.MovePosition(new Vector2(rb2.position.x, newY));
    }


    private void player2movment()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            rb2.linearVelocity = new Vector2(0, speed);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            rb2.linearVelocity = new Vector2(0, -1 * speed);
        }
        else
        {
            rb2.linearVelocity = new Vector2(0, 0);
        }

    }



}


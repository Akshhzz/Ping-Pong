using UnityEngine;
using UnityEngine.InputSystem;
public class Playermovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 8f ;
    public logicscript lgc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    private void Awake()
    {
       
    }
    void Start()
    {
        rb.linearVelocity = new Vector2(0, 0);
        lgc = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (lgc.isPause == false)
        {

            if (Keyboard.current.upArrowKey.isPressed)
            {
                rb.linearVelocity = Vector2.up * speed;

            }
            else if (Keyboard.current.downArrowKey.isPressed)
            {
                rb.linearVelocity = Vector2.down * speed;
            }
            else
            {
                rb.linearVelocity = new Vector2(0, 0);
            }
        }

        
    }


  
}

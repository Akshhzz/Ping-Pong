using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class Ballmovement : MonoBehaviour
{
    public Rigidbody2D rbball;
    public Rigidbody2D rb1;
    public Rigidbody2D rb2;

    public float speedx = 5.0f;
    public float speedy = 5.0f;
    public logicscript lgc;
    public bool isGameOver = false;
    public float xpos = 0.0f;  
    public float ypos = 0.0f;
    public  AudioClip ballhit;
    private  AudioSource audiosource;
    

    float GetHitOffsetY(Collision2D collision)
    {
        float ballY = rbball.position.y;
        float paddleY = collision.transform.position.y;
        float paddleHalfHeight = collision.collider.bounds.size.y / 2f;

        
        return (ballY - paddleY) / paddleHalfHeight;
    }


    private void Awake()
    {
        ballstart();

    }

    void Start()
    {
        lgc = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
        audiosource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        rbball.linearVelocity = new Vector2(speedx, speedy);
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Right")
        {

            speedx = -1f * speedx;
            xpos = rb1.position.x - 3.0f ;
            ypos = rb1.position.y;
            ballstart();
            lgc.addScore(2, 5);
            audiosource.pitch = 0.9f;
            audiosource.PlayOneShot(ballhit);

        }

        if (collision.gameObject.name == "Left")
        {

            speedx = -1f * speedx;
            xpos = rb2.position.x + 3.0f;
            ypos = rb2.position.y;
            ballstart();
            lgc.addScore(1, 5);
            audiosource.pitch = 0.9f;
            audiosource.PlayOneShot(ballhit);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (lgc.isPause == false)
        {

            // if (collision.gameObject.name == "Player" || collision.gameObject.name == "Opp")    speedx = -1.05f * speedx;

            
           // Debug.Log("Sound Played");

            if (collision.gameObject.name == "Up" || collision.gameObject.name == "Down")
            {
                speedy = -1 * speedy;
                audiosource.pitch = 2.5f;
                audiosource.PlayOneShot(ballhit);

            }

           


            if (collision.gameObject.name == "Player")
            {
                audiosource.pitch = 2.5f;
                audiosource.PlayOneShot(ballhit);

                float hitOffset = GetHitOffsetY(collision);
                float maxAngle = 70f;
                float angle = hitOffset * maxAngle * Mathf.Deg2Rad;
                float speed = Mathf.Sqrt(speedx * speedx + speedy * speedy);
                speed = Mathf.Clamp(speed + 0.1f, 5.0f, 10.0f);

                speedx = Mathf.Min (-5.0f, Mathf.Cos(angle) * -1.0f * speed); 
                speedy = Mathf.Max(Mathf.Sin(angle) * speed,5.0f);

                
                lgc.addScore(1);


            }

            if (collision.gameObject.name == "Opp")
            {
                audiosource.pitch = 2.5f;
                audiosource.PlayOneShot(ballhit);

                float hitOffset = GetHitOffsetY(collision);
                float maxAngle = 70f; 
                float angle = hitOffset * maxAngle * Mathf.Deg2Rad;
                float speed = Mathf.Sqrt(speedx * speedx + speedy * speedy);
                speed = Mathf.Clamp(speed + 0.1f, 5.0f, 10.0f);

                speedx = Mathf.Max (-Mathf.Cos(angle) * -1.0f * speed, 5.0f);
                speedy = Mathf.Max (Mathf.Sin(angle) * speed,5.0f );

               
                


                lgc.addScore(2);
            }     





        }

    }

    private void ballstart()
    {
        rbball.position = new Vector2(xpos,ypos) ;

        float x = Random.Range(-5.0f, 5.0f);
        while (x < 3 && x > -3)
        {
            x = Random.Range(-5.0f, 5.0f);
            if (x >= 3|| x <= - 3)
            {
                speedy = x;
                break;
            }
        }
        return;
    }





}

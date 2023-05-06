using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonScript : MonoBehaviour
{

    public int CannonAngle;
    public Transform Cannon;
    public Transform CannonStart;
    Vector2 cannonDirection; 
    public GameObject CannonBall;
    public GameObject Tracer;
    private float tracerTime;
    private int firethree;
    public float CannonBallSpeed;
    public DataScript TheData;
    public bool IfFinalLevel;
    public Transform TargetV1;
    

    // Start is called before the first frame update
    void Start()
    {
        //Set initial cannon angle and speed
        CannonAngle = 0;    
        CannonBallSpeed = 500;
        
        //connection to data script
        TheData = GameObject.FindGameObjectWithTag("DataTag").GetComponent<DataScript>();
        TheData.UpdateDegrees(CannonAngle);
        TheData.UpdatePower(CannonBallSpeed);
        tracerTime = 0f;
        firethree = 0; 

        //set conditions for levels
        if ((SceneManager.GetActiveScene().name) == "Level3") 
        {
            TheData.livesNum = 1;
        }
        if((SceneManager.GetActiveScene().name) == "LevelWin")
        {
            TheData.livesNum = 100;
            IfFinalLevel = true;
        }
        else
        {
            IfFinalLevel = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if at level 1 turn on tracers
        if(((SceneManager.GetActiveScene().name) == "Level1"))
        {
            if (tracerTime < .2f)
            {
                tracerTime = tracerTime + Time.deltaTime;
            }   
            else 
            {   FireTracer();
                firethree++;
                tracerTime = 0f;
                if (firethree >= 3) 
                {
                    tracerTime = - 1f;
                    firethree = 0;
                } 
            }
        }

        // continue if there are remaining lives
        if (TheData.ifPlay == true) 
        {
            // rotate up
            if(Input.GetKeyDown(KeyCode.UpArrow) == true)
            { 
                transform.Rotate(0, 0, 5);
                CannonAngle = CannonAngle + 5;
                UpdateCannonDirection();
                TheData.UpdateDegrees(CannonAngle);
            }

            // rotate down
            if(Input.GetKeyDown(KeyCode.DownArrow) == true)
            { 
                transform.Rotate(0, 0, -5);
                CannonAngle = CannonAngle - 5; 
                UpdateCannonDirection();
                TheData.UpdateDegrees(CannonAngle);
            }

            // increase power
            if(Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                CannonBallSpeed = CannonBallSpeed + 25.0f;
                TheData.UpdatePower(CannonBallSpeed);
            }

            // decrease power
            if(Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                CannonBallSpeed = CannonBallSpeed - 25.0f;
                TheData.UpdatePower(CannonBallSpeed);
            }

            // fire cannon
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                if (TheData.livesNum > 0)
                {
                    TheData.SubtractLives();
                    FireCannon();
                    tracerTime = -4f;
                    Debug.Log("Cannon Fired");

                    // move target if at final level
                    if (IfFinalLevel)
                    {
                        MoveTarget();
                    }
                }
            }
        }

        if (TheData.continueText.text != "" && 
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            if (!IfFinalLevel)
            {
                if ((TheData.continueText.text).IndexOf("continue") > 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene("Level1");
                }
            }
            else    
            {
                SceneManager.LoadScene("title screen");
            }
        }
    }

    void UpdateCannonDirection()
    {
        cannonDirection = (Vector2)CannonStart.position - (Vector2)Cannon.position;
    }
    void FireCannon()
    {
        GameObject CannonBallInstance = Instantiate(CannonBall,CannonStart.position, CannonStart.rotation);
        CannonBallInstance.GetComponent<Rigidbody2D>().AddForce(CannonBallInstance.transform.right * CannonBallSpeed);
    }
    void FireTracer()
    {
        GameObject tracerInstance = Instantiate(Tracer,CannonStart.position, CannonStart.rotation);
        tracerInstance.GetComponent<Rigidbody2D>().AddForce(tracerInstance.transform.right * CannonBallSpeed);
    }
    void MoveTarget()
    {  
        Debug.Log("Move the Target");
        TargetV1.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-4.0f, 4.0f),0);
    }

}

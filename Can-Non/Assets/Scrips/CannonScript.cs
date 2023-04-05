using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public int CannonAngle;
    public Transform Cannon;
    public Transform CannonStart;
    Vector2 cannonDirection; 
    public GameObject CannonBall;
    public float CannonBallSpeed;
    public DataScript TheData;
    // Start is called before the first frame update
    void Start()
    {
        CannonAngle = 0;    
        CannonBallSpeed = 500;
        TheData = GameObject.FindGameObjectWithTag("DataTag").GetComponent<DataScript>();
        TheData.UpdateDegrees(CannonAngle);
        TheData.UpdatePower(CannonBallSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (TheData.ifPlay == true) 
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) == true)
            { 
                transform.Rotate(0, 0, 5);
                CannonAngle = CannonAngle + 5;
                UpdateCannonDirection();
                TheData.UpdateDegrees(CannonAngle);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) == true)
            { 
                transform.Rotate(0, 0, -5);
                CannonAngle = CannonAngle - 5; 
                UpdateCannonDirection();
                TheData.UpdateDegrees(CannonAngle);
            }
            if(Input.GetKeyDown(KeyCode.RightArrow) == true)
            {
                CannonBallSpeed = CannonBallSpeed + 25.0f;
                TheData.UpdatePower(CannonBallSpeed);
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) == true)
            {
                CannonBallSpeed = CannonBallSpeed - 25.0f;
                TheData.UpdatePower(CannonBallSpeed);
            }
            if(Input.GetKeyDown(KeyCode.Space) == true)
            {
                if (TheData.livesNum > 0)
                {
                    TheData.SubtractLives();
                    FireCannon();
                }
                //CannonBallScript.FireCannon();
                Debug.Log("Cannon Fired");
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

}

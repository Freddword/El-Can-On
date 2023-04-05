using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour
{

    public float MaxAlive = 5;
    public float AliveTime = 0;
    public DataScript TheData;
    public Rigidbody2D cannonBallBody;
    // Start is called before the first frame update
    void Start()
    {
       TheData = GameObject.FindGameObjectWithTag("DataTag").GetComponent<DataScript>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (AliveTime < MaxAlive)
        {
            AliveTime = AliveTime + Time.deltaTime;
        }
        else
        {
            Debug.Log("Destory the object");
            Destroy(gameObject);
            if(TheData.livesNum < 1 && TheData.ifWin == false)
            {
                TheData.UpdateResult("You LOSE!");
            }
        }
        
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Target-V1")
        {
            Debug.Log("Collision with target");
            TheData.ifPlay = false;
            TheData.ifWin = true;
            TheData.UpdateResult("You WIN!");
        }
        cannonBallBody.velocity = Vector2.zero;
        cannonBallBody.angularVelocity = 0f;
    }
}

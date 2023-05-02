using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonBallScript : MonoBehaviour
{

    public float MaxAlive = 5f;
    public float AliveTime = 0f;
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
                TheData.UpdateResult("You LOSE!","press 'Enter' to restart...");
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
            TheData.UpdateResult("You WIN!", "press 'Enter' to continue...");
            
        }
        cannonBallBody.velocity = Vector2.zero;
        cannonBallBody.angularVelocity = 0f;
    }
}

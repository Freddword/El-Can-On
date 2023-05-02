using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracerScript : MonoBehaviour
{
    public float MaxAlive;
    public float AliveTime;
    public DataScript TheData;
    public Rigidbody2D tracerBody;
    // Start is called before the first frame update
    void Start()
    {
        MaxAlive = 5f;
        AliveTime = 0f;
        
        
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
            Debug.Log("Destory the tracer");
            Destroy(gameObject);
        }
    }
}

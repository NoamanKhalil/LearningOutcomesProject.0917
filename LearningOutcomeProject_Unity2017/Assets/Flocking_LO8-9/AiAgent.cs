using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------------------------------------------------//
//Based on https://gamedevelopment.tutsplus.com/series/understanding-steering-behaviors--gamedev-12732
//------------------------------------------------//
enum AIState
{
    Idle =0, Seek=1, Flee=2, Arrive=3, Pursuit=4, Evade=5
}
[RequireComponent(typeof(MySteeringBehaviour))]
public class AiAgent : MonoBehaviour
{
    public MySteeringBehaviour steer;
    public GameObject playerObj;
    public Transform target;
    public float Speed;
    public float turnSpeed;
    public int safeDist;
    public int minDist;

    private float tempPow;
    private AIState currentState;
    
    // Use this for initialization
    void Start ()
    {
        steer= this.gameObject.AddComponent<MySteeringBehaviour>();
        Speed = 6.0f;
        turnSpeed = 1.0f;
        safeDist = 20;
        minDist = 5;
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentState);
        tempPow = playerObj.GetComponent<PlayerController>().returnPower();
        switch (currentState)
        {
            
            case AIState.Idle:
                Idle();
                break;
            case AIState.Seek:
                // Seek();
                steer.Seek(playerObj, turnSpeed, minDist, Speed);
                break;
            case AIState.Flee:
                //Flee();
                steer.Flee(playerObj, turnSpeed, minDist, Speed);
                break;
            case AIState.Arrive:
                steer.Arrive(playerObj, turnSpeed, minDist, Speed);
                break;
            case AIState.Pursuit:
                steer.Pursuit(playerObj, turnSpeed, minDist, Speed , playerObj.GetComponent<PlayerController>().iVelocity); 
                break;
            case AIState.Evade:
                steer.Evade(playerObj, turnSpeed, minDist, Speed, playerObj.GetComponent<PlayerController>().iVelocity);
                break;
        }

        if (tempPow >= 90)
        {
            currentState = AIState.Flee;
        }
        else if (tempPow <= 80 && tempPow >= 20)
        {
            
            if (Vector3.Distance(playerObj.transform.position, this.transform.position) <= 10)
            {
              currentState = AIState.Arrive;
            }
            else
            {
                currentState = AIState.Seek;
            }
        }
        else if (tempPow <=20)
        {
            currentState = AIState.Evade;
        }
    
                // Seek();
                //Flee();
                // Arrive();
                // Pursuit();
                // Evade(); 
        }

    void Idle()
    {
        //Do nothing
    }

  /*  void Seek()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        if (dir.magnitude > minDist)
        {
            Vector3 moveVector = dir.normalized * Speed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Flee()
    {
        Vector3 dir = transform.position - target.position;
        dir.y = 0;
        if (dir.magnitude < minDist)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
            Vector3 moveVector = dir.normalized * Speed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Arrive()
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0;
        float distance = dir.magnitude;
        float slowDown = distance / 5;
        float speed = Speed * slowDown;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        Vector3 moveVector = dir.normalized * Time.deltaTime * speed;
        transform.position += moveVector;
    }

    void Pursuit()
    {
        int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<PlayerController>().iVelocity;
        Vector3 targetNextPos = target.transform.position + (targetSpeed * iterationAhead);
        Vector3 direction = targetNextPos - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        if (direction.magnitude > minDist)
        {
            Vector3 moveVector = direction.normalized * turnSpeed * Time.deltaTime;
            transform.position += moveVector;
        }
    }

    void Evade()
    {
        int iterationAhead = 30;
        Vector3 targetSpeed = target.gameObject.GetComponent<PlayerController>().iVelocity;
        Vector3 targetNextPos = target.position + (targetSpeed * iterationAhead);
        Vector3 dir = transform.position - targetNextPos;
        dir.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
        if (dir.magnitude < minDist)
        {
            Vector3 moveVector = dir.normalized * Speed * Time.deltaTime;
            transform.position += moveVector;
        }
    }*/
}

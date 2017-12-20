using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 10;
    public Text powerText;
    float power; 
    public  Vector3 iVelocity;

    void Start()
    {
        iVelocity = Vector3.zero;
         power = 100;
    }

    void Update()
    {
        powerText.text = "Power" + power;
        power -=  Time.deltaTime ; 

        Vector3 pos = transform.position;
        float hMove = Input.GetAxis("Horizontal");
        float fMove = Input.GetAxis("Vertical");
        if (Input.GetKey (KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * hMove * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward * fMove * Time.deltaTime * moveSpeed);
        }
        iVelocity = transform.position - pos;
    }

    public void addpower(float pow)
    {
        power+= pow;
    }

    public float returnPower()
    {
        return power;
    }
}

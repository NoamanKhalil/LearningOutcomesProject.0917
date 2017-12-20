using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScriptCs : MonoBehaviour {

   public GameObject PC;
   public  float powerToAdd;
    public float distToAddPow;

    float tempPow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempPow = PC.GetComponent<PlayerController>().returnPower();
        if (Vector3.Distance(PC.transform.position, this.transform.position) <= distToAddPow && tempPow <=99)
        {
           PC. GetComponent<PlayerController>().addpower(powerToAdd);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().addpower(powerToAdd);
    }

}

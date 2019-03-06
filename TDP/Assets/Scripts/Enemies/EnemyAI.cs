using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    private Rigidbody rb;
    public float speed, walkTime, attackRate;
    private BoxCollider attackBox;
    private Attack attack;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        attack = GetComponentInChildren<Attack>();
	}


    float wTimer = 0, atTimer = 0;
	// Update is called once per frame
	void Update () {

        wTimer += Time.deltaTime;
        atTimer += Time.deltaTime;

       if(wTimer > walkTime)
        {
            Walk();
            wTimer = 0; 
        }

       if(atTimer > attackRate)
        {
            Stand();
            attack.DoAttack();
            atTimer = 0;
        }

        if (this.GetComponent<Health>())
        {
            
        }

    }

    private void Walk()
    {
        rb.velocity = new Vector3(speed, 0, speed) * Random.Range(-2f,2f);
    }

    private void Stand()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

}

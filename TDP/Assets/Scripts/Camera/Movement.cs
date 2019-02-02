using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 follow = GameObject.Find("Player").transform.position;
        transform.position = new Vector3(follow.x, transform.position.y, follow.z - 30 + follow.y);
    }
}

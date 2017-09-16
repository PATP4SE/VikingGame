using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.transform.Translate(-2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            this.gameObject.transform.Translate(0, -2, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.Translate(2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.transform.Translate(0, 2, 0);
        }
    }
}

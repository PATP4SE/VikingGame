using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField] private int speed;
	[SerializeField] private GameObject enemy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.A))
        {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (-speed, 0, 0));
            //this.gameObject.transform.Translate(-2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, -speed));
            //this.gameObject.transform.Translate(0, -2, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (speed, 0, 0));
            //this.gameObject.transform.Translate(2, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, 0, speed));
            //this.gameObject.transform.Translate(0, 2, 0);
        }
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3 (0, speed, 0));
		}

		if (Input.GetKeyDown (KeyCode.E)) 
		{
			Instantiate (enemy);
		}

			
    }
}

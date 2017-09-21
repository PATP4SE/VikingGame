using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float jumpForce;
	[SerializeField] private float maxSpeed;
	[SerializeField] private GameObject enemy;

	private bool jump;
	private Rigidbody playerRigidbody;
	// Use this for initialization
	void Start () {
		playerRigidbody = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Debug.Log ("Velocity x: " + playerRigidbody.velocity.x + "  Velocity z: " + playerRigidbody.velocity.z);

		if (Mathf.Abs(playerRigidbody.velocity.x) >= maxSpeed || Mathf.Abs(playerRigidbody.velocity.z) >= maxSpeed || Mathf.Abs(playerRigidbody.velocity.x) + Mathf.Abs(playerRigidbody.velocity.z) >= maxSpeed) 
		{
			Vector3 v = playerRigidbody.velocity;
			if (playerRigidbody.velocity.x >= maxSpeed)
				v = new Vector3 (maxSpeed - 0.1f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
			else if (playerRigidbody.velocity.x <= -maxSpeed)
				v = new Vector3 (-maxSpeed + 0.1f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
			else if (playerRigidbody.velocity.z >= maxSpeed)
				v = new Vector3 (playerRigidbody.velocity.x, playerRigidbody.velocity.y, maxSpeed - 0.1f);
			else if (playerRigidbody.velocity.z <= -maxSpeed)
				v = new Vector3 (playerRigidbody.velocity.x, playerRigidbody.velocity.y, -maxSpeed + 0.1f);
			//else
			//	v = new Vector3 (playerRigidbody.velocity.x/2, playerRigidbody.velocity.y,playerRigidbody.velocity.z/2);

			playerRigidbody.velocity = v;
		}


		if (Input.GetKey(KeyCode.A))
        {
			playerRigidbody.AddForce (new Vector3 (-speed, 0, 0), ForceMode.Impulse);
        }
		if (Input.GetKey(KeyCode.S))
        {
			playerRigidbody.AddForce (new Vector3 (0, 0, -speed), ForceMode.Impulse);
        }
		if (Input.GetKey(KeyCode.D))
        {
			playerRigidbody.AddForce (new Vector3 (speed, 0, 0), ForceMode.Impulse);
        }
		if (Input.GetKey(KeyCode.W))
        {
			playerRigidbody.AddForce (new Vector3 (0, 0, speed), ForceMode.Impulse);
        }
		if (Input.GetKey (KeyCode.Space)) 
		{
			if (jump == true) 
			{
				playerRigidbody.AddForce (new Vector3 (0, jumpForce, 0), ForceMode.Impulse);
			}
		}

		if (Input.GetKey (KeyCode.E)) 
		{
			Instantiate (enemy);
		}

		if (this.gameObject.GetComponent<Rigidbody> ().velocity.y == 0) 
		{
			jump = true;
		} 
		else 
		{
			jump = false;
		}

			
    }
}

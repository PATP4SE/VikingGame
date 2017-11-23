#define DEBUG_RECTANGLE

using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour 
{

	[SerializeField] private GameObject subject;
	private GameObject camera;
	private Rect borders;
	private float xBorders = 0;
	private float yBorders = 0;
	private Vector3 middleCameraPosition;

	[SerializeField] private float BORDERS_WIDTH;
	[SerializeField] private float BORDERS_HEIGHT;


	// Use this for initialization
	void Start () 
	{
		this.initializeBordersWithResolution ();
		this.camera = this.gameObject;
		this.initializeCameraPosition ();
	}

	private void initializeBordersWithResolution()
	{
		xBorders = this.BORDERS_WIDTH / (1920f / Screen.width);
		yBorders = this.BORDERS_HEIGHT / (1080f / Screen.height);

		this.borders.xMin = this.subject.transform.position.x - xBorders;
		this.borders.xMax = this.subject.transform.position.x + xBorders;
		this.borders.yMin = this.subject.transform.position.y - (yBorders/2);
		this.borders.yMax = this.subject.transform.position.y + yBorders;
	}

	private void initializeCameraPosition()
	{
		this.camera.transform.position = new Vector3 (this.subject.transform.position.x, this.subject.transform.position.y, this.camera.transform.position.z);
	}

	// Update is called once per frame
	void Update () 
	{
		updateCameraPosition();
		#if DEBUG_RECTANGLE
		drawRectangle (this.borders);
		#endif
	}

	private void updateCameraPosition()
	{
		float subjectX = this.subject.transform.position.x;
		float subjectY = this.subject.transform.position.y;

		this.camera.transform.position = new Vector3 (this.camera.transform.position.x, this.subject.transform.position.y, this.camera.transform.position.z);
		if (isSubjectReachedBorders ())
		{

			float x = subjectX - this.camera.transform.position.x;
			float directionX = x / Mathf.Abs(x);

			this.middleCameraPosition = new Vector3(subjectX - ((this.borders.width/2) * directionX), this.subject.transform.position.y, this.camera.transform.position.z);

			this.camera.transform.position = this.middleCameraPosition;
			updateBorders();
		}
	}

	private void updateBorders()
	{
		this.borders.xMin = this.middleCameraPosition.x - xBorders ;
		this.borders.xMax = this.middleCameraPosition.x + xBorders ;
		this.borders.yMin = this.middleCameraPosition.y - (yBorders/2);
		this.borders.yMax = this.middleCameraPosition.y + yBorders ;
	}


	private bool isSubjectReachedBorders()
	{
		if (this.subject.transform.position.x >= this.borders.xMax || this.subject.transform.position.x <= this.borders.xMin||
			this.subject.transform.position.y >= this.borders.yMax || this.subject.transform.position.y <= this.borders.yMin) 
		{
			return true;

		}
		return false;
	}

	#region Debug Functions
	private void drawRectangle(Rect _rect)
	{
		// TOP
		Debug.DrawLine(new Vector3(_rect.xMin, _rect.yMin, this.subject.transform.position.z), new Vector3(_rect.xMax, _rect.yMin, this.subject.transform.position.z), Color.red);
		// BOTTOM
		Debug.DrawLine(new Vector3(_rect.xMin, _rect.yMax, this.subject.transform.position.z), new Vector3(_rect.xMax, _rect.yMax, this.subject.transform.position.z), Color.red);
		// LEFT
		Debug.DrawLine(new Vector3(_rect.xMin, _rect.yMin, this.subject.transform.position.z), new Vector3(_rect.xMin, _rect.yMax, this.subject.transform.position.z), Color.red);
		// RIGHT
		Debug.DrawLine(new Vector3(_rect.xMax, _rect.yMin, this.subject.transform.position.z), new Vector3(_rect.xMax, _rect.yMax, this.subject.transform.position.z), Color.red);
	}

	void OnDrawGizmos() 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(this.middleCameraPosition, 0.1f);
	}
	#endregion
}

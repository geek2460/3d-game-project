using UnityEngine;
using System.Collections;

public class character00_control : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float distanceH = speed * Time.deltaTime * Input.GetAxis("Horizontal");
		float distanceV = speed * Time.deltaTime * Input.GetAxis("Vertical");
		if (CameraBehavior.MoveToEnd) {
			
			transform.Translate (Vector3.left * -distanceH);
			transform.Translate (Vector3.forward * distanceV);
		}
	}
}

using UnityEngine;
using System.Collections;

public class action_camera00_control : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		speed = 10.0f;
	}

	// Update is called once per frame
	void Update () {
		float distanceH = speed * Time.deltaTime * Input.GetAxis("Horizontal");
		float distanceV = speed * Time.deltaTime * Input.GetAxis("Vertical");
		transform.Translate(Vector3.left* distanceH);
		transform.Translate(Vector3.forward* -distanceV);
	}
}

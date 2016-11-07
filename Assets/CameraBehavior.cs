using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {
	public Transform CommandPivot;
	public Transform ActionPivot;
	public static string selectedBody;
	public static bool MoveToEnd; 
	// Use this for initialization
	void Start () {
		gameObject.transform.position = CommandPivot.transform.position;
		gameObject.transform.LookAt(-CommandPivot.up);
		selectedBody = "body00";
		MoveToEnd = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (CameraStateManager.CurrentState == CameraStateManager.CameraState.Action) {
			Camera.main.transform.position = 
				GameObject.Find (selectedBody).transform.position 
					+ 5 * -Vector3.forward + 2* Vector3.up;
		}
	}

	public void ChangeToCommand() {
		
		iTween.MoveTo (gameObject, iTween.Hash(
			"x", CommandPivot.position.x,
			"y", 30,
			"z", CommandPivot.position.z,
			"axis", "x",
			"easetype", iTween.EaseType.easeOutExpo,
			"looktarget", new Vector3(CommandPivot.position.x, 0, CommandPivot.position.z),
			"lookahead", .5f,
			//"looktime", 1f,
			"speed", 8f,
			"onStart","MoveToStart"

		));
	}

	public void ChangeToAction() {
		iTween.MoveTo (gameObject, iTween.Hash(
			"position", GameObject.Find(selectedBody).transform.position 
				+ 5*-Vector3.forward + 2* Vector3.up,
			//easetype", iTween.EaseType.easeOutElastic,
			"looktarget", GameObject.Find(selectedBody).transform.position + Vector3.forward,
			"lookahead", .5f,
			"looktime", 1f,
			"speed", 8f,
			"onComplete","MoveToComplete"

		));
			
	}

	private void MoveToComplete()
	{
			MoveToEnd = true;
	}
	private void MoveToStart()
	{
		MoveToEnd = false;
	}
}

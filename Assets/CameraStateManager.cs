using UnityEngine;
using System.Collections;

public class CameraStateManager : MonoBehaviour {
	public enum CameraState {
		Command = 0,
		Action = 1,
		Battle = 2
	};

	public static CameraState CurrentState;
	private CameraState _previousState;

	public CameraBehavior MainCameraBehavior;

	// Use this for initialization
	void Start () {
		CurrentState = 0;
		_previousState = CurrentState;
		Camera.main.transform.RotateAround(Camera.main.transform.position,new Vector3(0,1,0),180);
		//ChangeState (CameraState.Action);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E))
			CurrentState = CameraState.Action;
		if (Input.GetKey (KeyCode.R))
			CurrentState = CameraState.Command;
		if (CurrentState != _previousState) {
			switch (CurrentState) {
			case (CameraState.Command):
				MainCameraBehavior.SendMessage ("ChangeToCommand");
				break;

			case (CameraState.Action):
				MainCameraBehavior.SendMessage ("ChangeToAction");
				break;
			}

			_previousState = CurrentState;
		}
	
	}

	public void ChangeState(CameraState state)
	{
		CurrentState = state;
	}
}

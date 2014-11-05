using UnityEngine;
using System.Collections;

public class DebugControls : MonoBehaviour {

	Vector3 startPos;

	void Start () {
		startPos = transform.position;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.F1))
			transform.position = startPos;
		if (Input.GetKeyDown(KeyCode.F2))
		{
			Screen.lockCursor = !Screen.lockCursor;

			MouseLookManager.ToggleDebugMouseLookActivated();
		}
	}
}

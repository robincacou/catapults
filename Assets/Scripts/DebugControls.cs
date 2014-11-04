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
		if (Input.GetKeyDown(KeyCode.F2)) // TODO Faire un manager de MouseLook qui possède plusieurs bools
										  // et se charge de véritablement activer ou pas les scripts
		{
			Screen.lockCursor = !Screen.lockCursor;

			foreach (MouseLook ml in GetComponentsInChildren<MouseLook>())
				ml.enabled = !ml.enabled;
		}
	}
}

using UnityEngine;
using System.Collections;

// This should only be used in the local instance of the player.
// Fetches the info from the managers (for instance, to activate MouseLook)
public class ManagersInfoHarvester : MonoBehaviour
{
	MouseLook playerMouseLook;
	MouseLook cameraMouseLook;

	public void Initialize(GameObject go)
	{
	}

	void Start()
	{
		playerMouseLook = GetComponent<MouseLook>();
		cameraMouseLook = transform.FindChild("Main Camera").GetComponent<MouseLook>();
	}

	void Update ()
	{
		bool activateMouseLook = MouseLookManager.ShouldActivateMouseLook();

		playerMouseLook.enabled = activateMouseLook;
		cameraMouseLook.enabled = activateMouseLook;
	}
}

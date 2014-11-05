using UnityEngine;
using System.Collections;


// Keeps track of whether any component wants to deactivate the mouseLooks
public static class MouseLookManager : object {

	static bool debugMouseLookActivated = true;
	static bool catapultsMouseLookActivated = true;

	public static void ToggleDebugMouseLookActivated()
	{
		debugMouseLookActivated = !debugMouseLookActivated;
	}

	public static void SetCatapultsMouseLookActivated(bool parValue)
	{
		catapultsMouseLookActivated = parValue;
	}
	
	public static bool ShouldActivateMouseLook()
	{
		return (debugMouseLookActivated && catapultsMouseLookActivated);
	}
}

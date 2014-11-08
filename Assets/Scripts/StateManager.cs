using UnityEngine;
using System.Collections;

public static class StateManager : object {

	// Represents what the player is currently doing
	public enum State {
		Connecting,		// The player has not been spawned yet
		Standard, 		// Standing and not doing anything
		CatapultAiming, // Standing in front of a catapult and left-clicking
		BlockCreating   // Right-clicking with the blockSelector tool on
	}

	static State currentState = State.Connecting;

	public static void SetState(State state)
	{
		currentState = state;
	}

	public static State CurrentState()
	{
		return currentState;
	}
}

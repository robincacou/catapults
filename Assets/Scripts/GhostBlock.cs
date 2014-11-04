using UnityEngine;
using System.Collections;

public class GhostBlock : MonoBehaviour {

	int collidingWith = 0;

	void OnTriggerEnter(Collider col)
	{
		collidingWith++;
	}

	void OnTriggerExit(Collider col)
	{
		collidingWith--;
	}

	public bool IsColliding()
	{
		return (collidingWith > 0);
	}

	void Start () {
	
	}

	void Update () {
	
	}
}

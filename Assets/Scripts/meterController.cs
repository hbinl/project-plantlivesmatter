using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class meterController : MonoBehaviour {
    public Transform meterPointer;
    private Vector3 currentPosition;
    public GameControl gameControl;
    public Vector3 newPosition;

	// Update is called once per frame
	void FixedUpdate () {
        newPosition = new Vector3(0.0f, 0.0f, 0.0f);
        currentPosition = UpdatePosition(newPosition);
    }

    Vector3 UpdatePosition(Vector3 newPosition)
    {
        currentPosition = newPosition;
        return currentPosition;
    }
}

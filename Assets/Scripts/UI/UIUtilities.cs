using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

public class UIUtilities : MonoBehaviour {

	// isCursorOnUI check whether mouse is clicking the UI or sprite
	public static bool isCursorOnUI()
	{
		EventSystem eventSystem = EventSystem.current;
		return eventSystem.IsPointerOverGameObject(-1);
	}
}

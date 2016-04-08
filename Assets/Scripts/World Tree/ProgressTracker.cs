using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressTracker : MonoBehaviour {
    public static float progess_percentage;
    public static float goldLeafRecieved;

    public Slider goldLeafPointer;
    // Use this for initialization
    void Start () {
        progess_percentage = 0f;
        goldLeafRecieved = 0;
	}

    void UpdateProgressMeter()
    {
        goldLeafPointer.value = goldLeafRecieved;
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressTracker : MonoBehaviour {
    public Slider goldLeafPointer;

    public void UpdateProgressMeter()
    {
        goldLeafPointer.value = WorldTreeProgress.worldTreeData.goldLeafRecieved;
    }
}

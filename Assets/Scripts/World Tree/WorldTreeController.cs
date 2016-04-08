using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldTreeController : MonoBehaviour {
    public Text progressText;
    public Text goldLeafText;

    // Update is called once per frame
    void Update()
    {
        ProgressTracker.progess_percentage = (ProgressTracker.goldLeafRecieved / 10000) * 100;
        progressText.text = "Progress: " + (int)ProgressTracker.progess_percentage + "% ";
    }
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class meterController : MonoBehaviour
{ 
    public Slider meterPointer;
    private float polRate;

    void Start()
    {
        polRate = GameControl.polRate;
        meterPointer.value = polRate;
    }
    /*
    public void UpdatePolRate(float newPolRate)
    {
        polRate -= newPolRate;
        meterPointer.value -= newPolRate / 100;
    }
    */
}
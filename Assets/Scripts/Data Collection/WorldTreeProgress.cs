using UnityEngine;
using System.Collections;

public class WorldTreeProgress : MonoBehaviour {
    public static WorldTreeProgress worldTreeData;

    public int goldLeafRecieved;

    // Use this for initialization
    void Awake()
    {
        if (worldTreeData == null)
        {
            DontDestroyOnLoad(gameObject);
            worldTreeData = this;
        }
        else if (worldTreeData != this)
        {
            Destroy(gameObject);
        }
    }
}

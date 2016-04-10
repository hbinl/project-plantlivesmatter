using UnityEngine;
using System.Collections;

public class GameBG : MonoBehaviour {

    public Sprite spriteChristmas;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (ItemSlot.christmasPack == true)
        {
            spriteRenderer.sprite = spriteChristmas;
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public float movementSpeed;
    public float timer;
    public float endHeight;
    public bool collected;

    public void Start()
    {
		// the starting position
        endHeight = transform.position.y - 2f;
        
		movementSpeed = 1.5f;
        timer = 3f;
        collected = false;
    }

    public void Update()
    {
		// set the timer for the spawn time
        timer -= Time.deltaTime;

		// to move down the coin
        MoveDownCoin();

        // move the coin to the top right corner as the moving animation
        if (collected)
        {
            
            transform.position = Vector3.Lerp(transform.position, CoinPosition.coinMeter.transform.position, 2.5f * Time.deltaTime);

        }
    }

    public void MoveDownCoin()
    {
        // move down coin
        if (timer <= 0f)
        {
            DestroyCoin();
        }
        else
        {
            if (transform.position.y > endHeight)
            {
                transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
            }
        }
    }

    public void DestroyCoin()
    {
        // Destroy coin object, add sound and animation if it is not clicked
        Destroy(this.gameObject);
    }

    public void OnMouseOver()
    {
		// if coin is collected
        if (Time.timeScale == 1)
        {
            GameControl.coinValue += 10;
            collected = true;
            
        }
        
    }
}

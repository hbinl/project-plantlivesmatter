using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateHealth : MonoBehaviour {
    public Slider m_currentHealth;
    public Image m_FillImage;
	// Use this for initialization
	void Awake () {
        m_FillImage = transform.GetChild(0).GetChild(1).GetComponentInChildren<Image>() as Image;
        m_currentHealth = GetComponentInChildren<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        m_currentHealth.value = m_currentHealth.value;
        m_FillImage.color = Color.Lerp(Color.red, Color.green, m_currentHealth.value / 100f);
    }

    public void changeHealthValue(float value)
    {
        m_currentHealth.value = value;
       
    }
}

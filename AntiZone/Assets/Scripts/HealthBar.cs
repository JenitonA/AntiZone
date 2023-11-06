using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Color high;
    public Color low;

    // Start is called before the first frame update
    public void setHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    
   
    

    // Update is called once per frame
    void Update()
    {
        
        //slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}

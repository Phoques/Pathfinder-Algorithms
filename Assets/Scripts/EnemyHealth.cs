using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    public Slider healthSlider;



    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.value = health;
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage();
        }
    }



    public void TakeDamage()
    {
        health -= 10;

    }


}

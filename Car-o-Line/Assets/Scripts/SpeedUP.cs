using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUP : MonoBehaviour
{
    //After Player touches the SpeedUp it activates the SpeedTheCar code

    [SerializeField] drawLine drawLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            drawLine.SpeedtheCar();
        }
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningHandler : MonoBehaviour
{
    //This code for warning signs

    [SerializeField] TextMeshProUGUI Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car" || collision.tag == "Wheel" )
        {
            Text.text = "Change Your Car to drive under it!!";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Car" || collision.tag == "Wheel")
        {
            Text.text = "";
        }
    }
}

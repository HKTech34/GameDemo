using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{

    [SerializeField] GameObject tapFingerIMG;

    void Start()
    {
        Destroy(tapFingerIMG, 4);
    }

   
}

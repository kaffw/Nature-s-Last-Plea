using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMinigameTutorial : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);    
        }        
    }
}

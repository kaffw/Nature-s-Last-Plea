using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MarkObjectiveDone : MonoBehaviour
{
    public GameObject instantiatingGO;
    //public TextMeshProUGUI text;
    public Text text;

    void Update()
    {
        if (instantiatingGO == null)
        {
            //text.color = Color.green;
            //text.faceColor = Color.green;
            text.color = Color.green;
            
            //enabled = false;
        }
    }
}

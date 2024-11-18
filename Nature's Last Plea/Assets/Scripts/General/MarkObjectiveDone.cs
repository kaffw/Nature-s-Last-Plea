using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MarkObjectiveDone : MonoBehaviour
{
    public GameObject instantiatingGO;
    public TextMeshProUGUI text;

    void Update()
    {
        if (instantiatingGO == null)
        {
            //text.color = Color.green;
            text.faceColor = Color.green;
            enabled = false;
        }
    }
}

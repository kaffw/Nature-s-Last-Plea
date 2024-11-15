using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehaviour : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] hitObjects = Physics2D.OverlapPointAll(mousePos);

            foreach (Collider2D hit in hitObjects)
            {
                GameObject clickedObject = hit.gameObject;
                Debug.Log("Clicked on: " + clickedObject.name);
            }
        }
    }
}
/*
if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] hits = Physics2D.OverlapPointAll(mousePosition);

            foreach (var hit in hits)
            {
                if (hit.CompareTag("GrateTrash"))
                {
                    Leaf clickedLeaf = hit.GetComponent<Leaf>();
                    if (clickedLeaf != null)
                    {
                        clickedLeaf.StartCoroutine(clickedLeaf.PickUpEffect());
                    }

                    return;
                }
            }
        } 

 */
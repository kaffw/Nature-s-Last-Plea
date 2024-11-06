using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveElementBehaviour : MonoBehaviour
{
    public int index; //manually initialized in the inspector
    public ObjectivesManager objectivesManager;

    public void ClickObjectiveElement()
    {
        objectivesManager.ShowLocation(index);
    }
}

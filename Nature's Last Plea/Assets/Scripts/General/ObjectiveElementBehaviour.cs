using System.Collections;
using UnityEngine;
using Cinemachine;

public class ObjectiveElementBehaviour : MonoBehaviour
{
    public CinemachineVirtualCamera cvc;
    private bool inCooldown = false;

    public void OnClickObjectiveElement()
    {
        // Only start the coroutine if not in cooldown
        if (!inCooldown)
        {
            StartCoroutine(StateTraverseCam());
            Debug.Log("objectiveelementbehvaiour");
        }
    }

    private IEnumerator StateTraverseCam()
    {
        inCooldown = true;

        cvc.Priority = 12;
        yield return new WaitForSecondsRealtime(3f);
        
        cvc.Priority = 8;
        
        inCooldown = false;
        
    }
}

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
        }
    }

    private IEnumerator StateTraverseCam()
    {
        inCooldown = true;

        cvc.Priority = 11;
        yield return new WaitForSecondsRealtime(3f);
        
        cvc.Priority = 9;
        
        inCooldown = false;
        
    }
}

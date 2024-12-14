using System.Collections;
using UnityEngine;
using Cinemachine;

public class LocateObjectiveBehaviour : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public CinemachineVirtualCamera virtualCamera;
    private Transform originPos;

    ObjectivesManager objMan;

    void Awake()
    {
        objMan = FindObjectOfType<ObjectivesManager>();
    }

    void Start()
    {
        originPos = GameObject.Find("Aurora").transform;
        target = transform;
    }

    public void MoveToTarget()
    {
        if(!ObjectivesManager.camTraversalInAction)
        {
            StartCoroutine(objMan.CamTraversalCooldown());
            Time.timeScale = 1;
            //virtualCamera.Follow = target;
            virtualCamera.Priority = 12;
            StartCoroutine(Return());
        }
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(3f);
        virtualCamera.Priority = 8;
        //virtualCamera.Follow = originPos;
    }
}

using System.Collections;
using UnityEngine;
using Cinemachine;

public class LocateObjectiveBehaviour : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public CinemachineVirtualCamera virtualCamera;
    private Transform originPos;


    void Start()
    {
        originPos = GameObject.Find("Aurora").transform;
        target = transform;
    }

    public void MoveToTarget()
    {
        Time.timeScale = 1;
        virtualCamera.Follow = target;
        StartCoroutine(Return());
    }

    IEnumerator Return()
    {
        yield return new WaitForSeconds(3f);
        virtualCamera.Follow = originPos;
    }
}

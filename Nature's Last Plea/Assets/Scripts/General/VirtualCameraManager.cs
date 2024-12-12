using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCameraManager : MonoBehaviour
{
    public static bool inMinigame;
    CinemachineVirtualCamera cvc;
    GameObject player;
    [SerializeField]
    Animator fadeAnim;
    bool called;

    void Awake()
    {
        cvc = GameObject.Find("Virtual Camera Player").GetComponent<CinemachineVirtualCamera>();
        player = GameObject.Find("Aurora");
        fadeAnim = GameObject.Find("Fade").GetComponent<Animator>();
        inMinigame = false;
        called = false;
    }

    void Update()
    {
        if(inMinigame)
        {
            cvc.Follow = transform;
            if(!called) { Fades(); called = true; }
        }
        else
        {
            cvc.Follow = player.transform;
            called = false;
        }
    }

    public void Fades()
    {
        fadeAnim.SetTrigger("Fade");
    }
}

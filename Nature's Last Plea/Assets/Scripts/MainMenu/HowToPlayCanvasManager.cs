using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayCanvasManager : MonoBehaviour
{
    public GameObject controlsView, uiAndLevelsView;

    public void SwapHowToPlayView()
    {
        controlsView.SetActive(!controlsView.activeSelf);
        uiAndLevelsView.SetActive(!controlsView.activeSelf);
    }
}

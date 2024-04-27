using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public GameObject controls;

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void Controls()
    {
        controls.SetActive(true);
    }
    public void ExitControls()
    {
        controls.SetActive(false);
    }
}
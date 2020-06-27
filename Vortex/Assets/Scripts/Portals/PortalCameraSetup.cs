using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraSetup : MonoBehaviour
{
    public Camera orangeCamera;
    public Material orangePortalMat;

    public Camera blueCamera;
    public Material bluePortalMat;
    void Start()
    {
        if(orangeCamera.targetTexture != null)
        {
            orangeCamera.targetTexture.Release();
        }
        orangeCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        orangePortalMat.mainTexture = orangeCamera.targetTexture;

        if (blueCamera.targetTexture != null)
        {
            blueCamera.targetTexture.Release();
        }
        blueCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        bluePortalMat.mainTexture = blueCamera.targetTexture;
    }
}

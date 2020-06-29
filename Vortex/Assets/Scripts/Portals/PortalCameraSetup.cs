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
        if (blueCamera.targetTexture != null)
        {
            blueCamera.targetTexture.Release();
        }
        orangeCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        blueCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        orangePortalMat.mainTexture = blueCamera.targetTexture;
        bluePortalMat.mainTexture = orangeCamera.targetTexture;
    }
}

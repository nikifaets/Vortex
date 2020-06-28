using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraBehaviour : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portalOfCamera;
    public Transform linkedPortal;
    public MeshRenderer screen;



    void Update()
    {
        /*
        Vector3 playerOffsetFromPortal = playerCamera.position - linkedPortal.position;
        transform.position = portalOfCamera.position - playerOffsetFromPortal;
        
        */
        float angularDiffOfPortalRotations = Quaternion.Angle(portalOfCamera.rotation, linkedPortal.rotation);
        Quaternion portalRotationDiff = Quaternion.AngleAxis(angularDiffOfPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        
        
        /*
        var matrix = transform.localToWorldMatrix * linkedPortal.localToWorldMatrix * playerCamera.localToWorldMatrix;
        transform.SetPositionAndRotation(matrix.GetColumn(3), matrix.rotation);
        */
    }

}

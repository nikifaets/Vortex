using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform linkedPortal;
    private Transform objectToTeleport;
    public bool objectIsInPortal = false;

    void Update()
    {

        if (objectIsInPortal)
        {
            Vector3 portalToCollided = objectToTeleport.position - transform.position;
            float rotationDiff = -Quaternion.Angle(transform.rotation, linkedPortal.rotation);
            rotationDiff += 180;
            objectToTeleport.Rotate(Vector3.up, rotationDiff);

            Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToCollided;
            objectToTeleport.position = linkedPortal.position + positionOffset + linkedPortal.forward * 5f;
            objectIsInPortal = false;
        }
        
        
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        objectToTeleport = collider.transform;
        objectIsInPortal = true;
        
    }


}

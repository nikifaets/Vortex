using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform linkedPortal;
    private Transform objectInPortal;
    private bool objectIsInPortal = false;
    
    void Update()
    {

        if (objectIsInPortal)
        {
            Debug.Log("transforming");
            if (objectInPortal == null) Debug.Log("null");
            Vector3 portalToCollided = objectInPortal.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToCollided);

            if (dotProduct < 0f)
            {
                float rotationDiff = Quaternion.Angle(transform.rotation, linkedPortal.rotation);
                objectInPortal.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToCollided;
                objectInPortal.position = linkedPortal.position + positionOffset;
            }
            objectIsInPortal = false;
        }
    }
    private void OnTriggerEnter(Collider collided)
    {
        //objectIsInPortal = true;
        //objectInPortal = collided.gameObject.transform;
        //collided.gameObject.transform.Translate(linkedPortal.transform.position - collided.transform.position, Space.World);
        //collided.transform.position = linkedPortal.position;
        collided.transform.position = new Vector3(10, 10, 10);
        Debug.Log("Collided with " + collided.gameObject.name);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public GameObject linkedPortal;
  //  private Transform objectInPortal;
    public bool alreadyTeleported = false;
    
    void Update()
    {
        /*
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
        */
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (!alreadyTeleported)
        {
            Debug.Log("Collided with " + collider.gameObject.name);
            //collided.gameObject.transform.Translate(linkedPortal.transform.position - collided.transform.position, Space.World);
            //objectInPortal = collided.gameObject.transform;
            collider.transform.position = linkedPortal.transform.TransformPoint(transform.InverseTransformPoint(transform.position));
            collider.transform.rotation = linkedPortal.transform.rotation * Quaternion.Inverse(transform.rotation) * collider.transform.rotation;
            Rigidbody objRigid = collider.GetComponent<Rigidbody>();
            objRigid.velocity = linkedPortal.transform.TransformDirection(transform.InverseTransformDirection(objRigid.velocity));
            linkedPortal.GetComponent<PortalTeleporter>().alreadyTeleported = true;
        }
        /*
        collider.transform.position = linkedPortal.transform.position + linkedPortal.transform.forward * 10;
        collider.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        */
    }
    private void OnTriggerExit(Collider other)
    {
        alreadyTeleported = false;
    }
}

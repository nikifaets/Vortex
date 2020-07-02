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
            //linkedPortal.GetComponent<PortalTeleporter>().alreadyTeleported = true;
            Debug.Log("transforming");
            Vector3 portalToCollided = objectToTeleport.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToCollided);

            if (dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, linkedPortal.rotation);
                rotationDiff += 180;
                objectToTeleport.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToCollided;
                objectToTeleport.position = linkedPortal.position + positionOffset;
                objectIsInPortal = false;
            }
        }
        
        
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("test");
        objectToTeleport = collider.transform;
        objectIsInPortal = true;
        //collider.transform.position = linkedPortal.transform.position + linkedPortal.transform.forward * 1.5f;
        //collider.transform.rotation = Quaternion.LookRotation(linkedPortal.transform.forward);
        /*
        if (collider.tag == "Player" && !playerIsInPortal)
        {
            Debug.Log("transforming " + collider.name);
            linkedPortal.GetComponent<PortalTeleporter>().playerIsInPortal = true;
        }
        */
        //collided.gameObject.transform.Translate(linkedPortal.transform.position - collided.transform.position, Space.World);
        //linkedPortal.GetComponent<PortalTeleporter>().alreadyTeleported = true;
        //collider.transform.position = linkedPortal.transform.TransformPoint(transform.InverseTransformPoint(transform.position));
        //collider.transform.rotation = linkedPortal.transform.rotation * Quaternion.Inverse(transform.rotation) * collider.transform.rotation;
        //Rigidbody objRigid = collider.GetComponent<Rigidbody>();
        //objRigid.velocity = linkedPortal.transform.TransformDirection(transform.InverseTransformDirection(objRigid.velocity));

        /*
        collider.transform.position = linkedPortal.transform.position + linkedPortal.transform.forward * 10;
        collider.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        */
    }


}

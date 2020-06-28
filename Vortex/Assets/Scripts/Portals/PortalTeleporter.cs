using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public GameObject linkedPortal;
    public bool playerIsInPortal = false;
    
    void Update()
    {
        /*
        if (playerIsInPortal)
        {
            //linkedPortal.GetComponent<PortalTeleporter>().alreadyTeleported = true;
            Debug.Log("transforming");
             Vector3 portalToCollided = player.position - transform.position;
             float dotProduct = Vector3.Dot(transform.up, portalToCollided);

                if (dotProduct < 0f)
                {
                    float rotationDiff = -Quaternion.Angle(transform.rotation, linkedPortal.rotation);
                    rotationDiff += 180;
                    player.Rotate(Vector3.up, rotationDiff);
                    Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToCollided;
                    player.position = linkedPortal.position + positionOffset;
                playerIsInPortal = false;
                }
        }
        */
        
        
        
    }
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
            Debug.Log("transforming player");
            collider.transform.Translate(new Vector3(10,10,10));
        }
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

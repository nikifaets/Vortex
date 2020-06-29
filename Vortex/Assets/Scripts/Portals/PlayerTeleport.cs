using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("controllercolliderhit");
        if(hit.gameObject.tag.Equals ("Portal"))
        {
            Debug.Log("controller collided with portal");
            Transform linkedPortal = hit.gameObject.GetComponent<PortalTeleporter>().transform;
            transform.position = linkedPortal.position;
        }
    }
}

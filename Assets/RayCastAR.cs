using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RayCastAR : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject objToPlane;
    public Camera raycastCam;
    private GameObject ObjectIns;
    public List<ARRaycastHit> hit = new List<ARRaycastHit>();
    private void Update()
    {
        if(raycastManager == null)
        {
            return;
        }    
        if(raycastCam == null)
        {
            return;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = raycastCam.ScreenPointToRay(Input.mousePosition);
            if(raycastManager.Raycast(ray, hit))
            {
                Pose pose = hit[0].pose;
                if(ObjectIns == null)
                {
                    ObjectIns = Instantiate(objToPlane,pose.position,pose.rotation);
                }
                else
                {
                    ObjectIns.transform.SetPositionAndRotation(pose.position,pose.rotation);
                }
            }
        }
    }
}

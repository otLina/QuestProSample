using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPassthrough : MonoBehaviour
{
    OVRPassthroughLayer passthroughLayer;
    [SerializeField]
    OVRCameraRig ovrCameraRig;
    [SerializeField]
    GameObject avatar1;

    // Start is called before the first frame update
    void Start()
    {
        //var ovrCameraRig = GameObject.FindObjectOfType<OVRCameraRig>();
        if (ovrCameraRig == null)
        {
            Debug.LogError("Scene does not contain an OVRCameraRig");
            return;
        }

        passthroughLayer = ovrCameraRig.GetComponent<OVRPassthroughLayer>();
        if (passthroughLayer == null)
        {
            Debug.LogError("OVRCameraRig does not contain an OVRPassthroughLayer component");
        }
    }

    private void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
            avatar1.SetActive(false);
            Passthrough();
        }
    }

    private void Passthrough()
    {
        passthroughLayer.hidden = !passthroughLayer.hidden;
    }
}

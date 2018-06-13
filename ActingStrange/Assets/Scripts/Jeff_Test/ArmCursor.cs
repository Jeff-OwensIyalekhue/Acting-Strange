using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class ArmCursor : MonoBehaviour {

    public BasicAvatarModel skeleton;
	// Update is called once per frame
	void Update () {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(skeleton.getRawWorldPosition(JointType.ElbowRight), skeleton.getRawWorldPosition(JointType.HandRight) - skeleton.getRawWorldPosition(JointType.ElbowRight), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(skeleton.getRawWorldPosition(JointType.ElbowRight), (skeleton.getRawWorldPosition(JointType.HandRight) - skeleton.getRawWorldPosition(JointType.ElbowRight)) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(skeleton.getRawWorldPosition(JointType.ElbowRight), (skeleton.getRawWorldPosition(JointType.HandRight) - skeleton.getRawWorldPosition(JointType.ElbowRight)) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}

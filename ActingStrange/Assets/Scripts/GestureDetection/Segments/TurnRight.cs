using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class TurnRightSegment1 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightFoot = skeleton.getRawWorldPosition(JointType.FootRight);
        Vector3 leftAnkel = skeleton.getRawWorldPosition(JointType.AnkleLeft);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);

        //position detection
        if (leftShoulder.z <= rightShoulder.z)
        {
            if (rightFoot.y > leftAnkel.y)
            {
                //Debug.Log("TurnRight seg1");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}

public class TurnRightSegment2 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightFoot = skeleton.getRawWorldPosition(JointType.FootRight);
        Vector3 leftAnkel = skeleton.getRawWorldPosition(JointType.AnkleLeft);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);

        //position detection
        if (leftShoulder.z > rightShoulder.z)
        {
            if (rightFoot.y < leftAnkel.y)
            {
                //Debug.Log("TurnRight seg2");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}
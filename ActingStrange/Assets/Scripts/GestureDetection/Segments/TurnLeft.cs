using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class TurnLeftSegment1 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 leftFoot = skeleton.getRawWorldPosition(JointType.FootLeft);
        Vector3 rightAnkel = skeleton.getRawWorldPosition(JointType.AnkleRight);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);

        //position detection
        if (leftShoulder.z >= rightShoulder.z)
        {
            if (leftFoot.y > rightAnkel.y)
            {
                //Debug.Log("TurnLeft seg1");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}

public class TurnLeftSegment2 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 leftFoot = skeleton.getRawWorldPosition(JointType.FootLeft);
        Vector3 rightAnkel = skeleton.getRawWorldPosition(JointType.AnkleRight);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);

        //position detection
        if (leftShoulder.z<rightShoulder.z)
        {
            if (leftFoot.y < rightAnkel.y)
            {
                //Debug.Log("TurnLeft seg2");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}
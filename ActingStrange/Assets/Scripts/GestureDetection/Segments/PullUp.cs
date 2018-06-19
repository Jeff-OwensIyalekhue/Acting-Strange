using UnityEngine;
using System.Collections;
using Windows.Kinect;


public class PullUpSegment1 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 leftHand = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        //position detection
        if (leftHand.y < hip.y && rightHand.y < hip.y)
        {
            //Debug.Log("PullUp seg1");
            return GesturePartResult.Succeed;
        }
        return GesturePartResult.Pausing;
    }
}

public class PullUpSegment2 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 leftHand = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);

        //position detection
        if (rightHand.y < hip.y && leftHand.y >= hip.y && leftHand.y <= shoulder.y)
        {
            //Debug.Log("PullUp seg2");
            return GesturePartResult.Succeed;
        }
        return GesturePartResult.Pausing;
    }
}

public class PullUpSegment3 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 leftHand = skeleton.getRawWorldPosition(JointType.HandLeft);
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);

        //position detection
        if (rightHand.y < hip.y && leftHand.y > shoulder.y)
        {
            //Debug.Log("PullUp seg3");
            return GesturePartResult.Succeed;
        }
        return GesturePartResult.Pausing;
    }
}
using UnityEngine;
using System.Collections;
using Windows.Kinect;


public class ClapSegment1 : IRelativeGestureSegment
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
        Vector3 leftElbow = skeleton.getRawWorldPosition(JointType.ElbowLeft);
        Vector3 rightElbow = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        //position detection
        if (leftHand.y < shoulder.y && rightHand.y < shoulder.y && leftHand.y > hip.y && rightHand.y > hip.y)
        {
            //Debug.Log("HandL: "+leftHand.z+" ShoulderR: "+ rightShoulder.z);
            if (leftHand.x < leftElbow.x && rightHand.x > rightElbow.x)
            {
                //Debug.Log("Clap seg1");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}

public class ClapSegment2 : IRelativeGestureSegment
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
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        //position detection
        if (leftHand.y < shoulder.y && rightHand.y < shoulder.y && leftHand.y > hip.y && rightHand.y > hip.y)
        {
            //Debug.Log("HandL: "+leftHand.z+" ShoulderR: "+ rightShoulder.z);
            if (leftHand.x > leftShoulder.x && rightHand.x < rightShoulder.x && leftHand.x < rightShoulder.x && rightHand.x > leftShoulder.x)
            {
                //Debug.Log("Clap seg1");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}
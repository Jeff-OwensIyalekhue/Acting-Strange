using UnityEngine;
using System.Collections;
using Windows.Kinect;


public class PunchDownSegment1 : IRelativeGestureSegment
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
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 rightShoulder = skeleton.getRawWorldPosition(JointType.ShoulderRight);



        //position detection
        if (leftHand.x >= leftShoulder.x && rightHand.x <= rightShoulder.x) {

            if (leftHand.y > shoulder.y && rightHand.y > shoulder.y)
            {
                //Debug.Log("PunchDown seg1");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Fail;
    }
}

public class PunchDownSegment2 : IRelativeGestureSegment
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
        Vector3 shoulder = skeleton.getRawWorldPosition(JointType.SpineShoulder);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        if (leftHand.y < shoulder.y && rightHand.y < shoulder.y)
        {
            
            if(leftHand.y >= hip.y && rightHand.y >= hip.y)
            {
                //Debug.Log("PunchDown seg2");
                return GesturePartResult.Succeed;
            }
            //return GesturePartResult.Pausing;
        }
        return GesturePartResult.Pausing;
    }
}

public class PunchDownSegment3 : IRelativeGestureSegment
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

        if (leftHand.y < hip.y && rightHand.y < hip.y)
        {
            //Debug.Log("PunchDown succeed");
            return GesturePartResult.Succeed;
        }
        return GesturePartResult.Pausing;
    }
}
using UnityEngine;
using System.Collections;
using Windows.Kinect;


public class CircleSegment1 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);

        //position detection
        if (rightHand.y >= head.y)
        {
            //Debug.Log("Cirlce seg1");
            return GesturePartResult.Succeed;
            //ggf. add hand.z betw. shoulders
        }
        return GesturePartResult.Pausing;
    }
}

public class CircleSegment2 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 rightElbow = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        if ( rightHand.y < head.y && rightHand.y >hip.y)
        {

            if (rightHand.x > rightElbow.x)
            {
                //Debug.Log("Circle seg2");
                return GesturePartResult.Succeed;
            }
            //return GesturePartResult.Pausing;
        }
        return GesturePartResult.Pausing;
    }
}

public class CircleSegment3 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        //position detection
        if (rightHand.y <= hip.y)
        {
            //Debug.Log("Cirlce seg3");
            return GesturePartResult.Succeed;
            //ggf. add hand.z betw. shoulders
        }
        return GesturePartResult.Pausing;
    }
}

public class CircleSegment4 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 rightHand = skeleton.getRawWorldPosition(JointType.HandRight);
        Vector3 leftShoulder = skeleton.getRawWorldPosition(JointType.ShoulderLeft);
        Vector3 head = skeleton.getRawWorldPosition(JointType.Head);
        Vector3 hip = skeleton.getRawWorldPosition(JointType.SpineBase);

        if (rightHand.y < head.y && rightHand.y > hip.y)
        {

            if (rightHand.x < leftShoulder.x)
            {
                //Debug.Log("Circle seg4");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}
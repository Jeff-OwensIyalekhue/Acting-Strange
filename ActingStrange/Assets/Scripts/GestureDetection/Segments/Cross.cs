﻿using UnityEngine;
using System.Collections;
using Windows.Kinect;


public class CrossSegment1 : IRelativeGestureSegment
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

        //position detection
        if (leftHand.y < leftElbow.y && rightHand.y < rightElbow.y)
        {
            //Debug.Log("HandL: "+leftHand.z+" ShoulderR: "+ rightShoulder.z);
            if (leftHand.x > rightElbow.x && rightHand.x < leftElbow.x)
            {
                Debug.Log("Cross seg1"); 
              return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}

public class CrossSegment2 : IRelativeGestureSegment
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
        Vector3 shoulderMid = skeleton.getRawWorldPosition(JointType.SpineShoulder);

        //position detection
        if (leftHand.y <= shoulderMid.y && rightHand.y <= shoulderMid.y)
        {
            if (leftHand.x < leftShoulder.x && rightHand.x > rightShoulder.x)
            {
                Debug.Log("Cross seg2");
                return GesturePartResult.Succeed;
            }
        }
        return GesturePartResult.Pausing;
    }
}
using UnityEngine;
using System.Collections;
using Windows.Kinect;


//rework!

public class PushFwrdSegment1 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 elbowRight = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 shoulderRight = skeleton.getRawWorldPosition(JointType.ShoulderRight);

        //position detection
        if(elbowRight.z<= shoulderRight.z)
        {
            return GesturePartResult.Succeed;
            Debug.Log("PushFwrd seg1");
        }
        return GesturePartResult.Fail;
    }
}

public class PushFwrdSegment2 : IRelativeGestureSegment
{

    /// <summary>
    /// Checks the gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
    public GesturePartResult CheckGesture(BasicAvatarModel skeleton)
    {
        //get necessary joint positions
        Vector3 elbowRight = skeleton.getRawWorldPosition(JointType.ElbowRight);
        Vector3 shoulderRight = skeleton.getRawWorldPosition(JointType.ShoulderRight);
        Vector3 handRight = skeleton.getRawWorldPosition(JointType.HandRight);

        if (elbowRight.z > shoulderRight.z)
        {
            if (handRight.y <= shoulderRight.y)
            {
                return GesturePartResult.Succeed;
                Debug.Log("PushFwrd succeed");
            }
            return GesturePartResult.Pausing;
            Debug.Log("PushFwrd pausing");
        }
        return GesturePartResult.Fail;
        Debug.Log("PushFwrd failed");
    }
}
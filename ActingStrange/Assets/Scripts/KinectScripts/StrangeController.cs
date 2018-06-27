using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class StrangeController : BasicAvatarController
{
    public override void Start()
    {
        // find transforms of model
        ////SpineBase = GameObject.Find("Character1_Hips").transform;
        //SpineMid = GameObject.Find("Character1_Spine2").transform;
        Neck = GameObject.Find("Torso").transform;
        Head = GameObject.Find("Neck").transform;
        ShoulderLeft = GameObject.Find("Shoulder_L").transform;
        ElbowLeft = GameObject.Find("Arm_L").transform;
        WristLeft = GameObject.Find("Forearm_L").transform;
        HandLeft = GameObject.Find("Hand_L").transform;
        ShoulderRight = GameObject.Find("Shoulder_R").transform;
        ElbowRight = GameObject.Find("Arm_R").transform;
        WristRight = GameObject.Find("Forearm_R").transform;
        HandRight = GameObject.Find("Hand_R").transform;
        ////HipLeft = GameObject.Find("Character1_LeftUpLeg").transform;
        ////KneeLeft = GameObject.Find("Character1_LeftLeg").transform;
        ////AnkleLeft = GameObject.Find("Character1_LeftFoot").transform;
        ////FootLeft = GameObject.Find("Character1_LeftToeBase").transform;
        ////HipRight = GameObject.Find("Character1_RightUpLeg").transform;
        ////KneeRight = GameObject.Find("Character1_RightLeg").transform;
        ////AnkleRight = GameObject.Find("Character1_RightFoot").transform;
        ////FootRight = GameObject.Find("Character1_RightToeBase").transform;
        ////SpineShoulder = GameObject.Find("Character1_Spine2").transform;
        //HandTipLeft = GameObject.Find("Character1_LeftHandIndex1").transform;
        //ThumbLeft = GameObject.Find("Character1_LeftHandThumb1").transform;
        //HandTipRight = GameObject.Find("Character1_RightHandIndex1").transform;
        //ThumbRight = GameObject.Find("Character1_RightHandThumb1").transform;

        base.Start();
    }

    public virtual void Update()
    {
        // apply base Update function, which rotates all known standard joints
        base.Update();
    }




}

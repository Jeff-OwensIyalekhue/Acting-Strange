using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GestureController gc;

	// Use this for initialization
	void Start () {
        gc.GestureRecognizedInController += OnGestureRecognized;
        IRelativeGestureSegment[] swipeLeft = { new SwipeToLeftSegment1(),
            new SwipeToLeftSegment2(),
            new SwipeToLeftSegment3() };
        gc.AddGesture("SwipeLeft", swipeLeft);
        IRelativeGestureSegment[] swipeLeftBack = { new SwipeToLeftSegment3(),
            new SwipeToLeftSegment2(),
            new SwipeToLeftSegment1() };
        gc.AddGesture("SwipeLeftBack", swipeLeftBack);

        IRelativeGestureSegment[] pullLeft = { new PullToLeftSegment1(), new PullToLeftSegment2(), new PullToLeftSegment3(), };
        gc.AddGesture("PullLeft", pullLeft);

        //IRelativeGestureSegment[] pushFwrd = { new PushFwrdSegment1(), new PushFwrdSegment2()};
        //gc.AddGesture("PushFwrd", pushFwrd);

        IRelativeGestureSegment[] punchDown = { new PunchDownSegment1(), new PunchDownSegment2(), new PunchDownSegment3() };
        gc.AddGesture("PunchDown", punchDown);
    }

    void OnGestureRecognized(object sender, GestureEventArgs e)
    {
        if (e.GestureName == "SwipeLeft")
        {
            Debug.Log("Swipe Recognized");

        }
        if (e.GestureName == "PullLeft")
        {
            Debug.Log("PullLeft Recognized");
        }
        if (e.GestureName == "SwipeLeftBack")
        {
            Debug.Log("SwipeBack Recognized");

        }
        if (e.GestureName == "PushFwrd")
        {
            Debug.Log("pushFwrd Recognized");

        }
        if (e.GestureName == "PunchDown")
        {
            Debug.Log("PunchDown Recognized");

        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}

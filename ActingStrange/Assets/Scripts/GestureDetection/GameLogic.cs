using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

    public GestureController gc;
    public GameObject playerAvatar;

    public Spellbook spellbook;

    public WaveManager waveManager;

	// Use this for initialization
	void Start () {
        gc.GestureRecognizedInController += OnGestureRecognized;

        IRelativeGestureSegment[] swipeLeft = { new SwipeToLeftSegment1(), new SwipeToLeftSegment2(), new SwipeToLeftSegment3() };
        gc.AddGesture("SwipeLeft", swipeLeft);

        IRelativeGestureSegment[] swipeRight = { new SwipeToRightSegment1(), new SwipeToRightSegment2(), new SwipeToRightSegment3() };
        gc.AddGesture("SwipeRight", swipeRight);

        //IRelativeGestureSegment[] swipeLeftBack = { new SwipeToLeftSegment3(),
        //    new SwipeToLeftSegment2(),
        //    new SwipeToLeftSegment1() };
        //gc.AddGesture("SwipeLeftBack", swipeLeftBack);

        //IRelativeGestureSegment[] pullLeft = { new PullToLeftSegment1(), new PullToLeftSegment2(), new PullToLeftSegment3(), };
        //gc.AddGesture("PullLeft", pullLeft);

        //IRelativeGestureSegment[] pushFwrd = { new PushFwrdSegment1(), new PushFwrdSegment2()};
        //gc.AddGesture("PushFwrd", pushFwrd);

        IRelativeGestureSegment[] punchDown = { new PunchDownSegment1(), new PunchDownSegment2(), new PunchDownSegment3() };
        gc.AddGesture("PunchDown", punchDown);

        IRelativeGestureSegment[] pullUp = { new PullUpSegment1(), new PullUpSegment2(), new PullUpSegment3() };
        gc.AddGesture("PullUp", pullUp);

        IRelativeGestureSegment[] circle = { new CircleSegment1(), new CircleSegment2(), new CircleSegment3() ,new CircleSegment4(), new CircleSegment1() };
        gc.AddGesture("Circle", circle);

        //IRelativeGestureSegment[] cross = { new CrossSegment1(), new CrossSegment2()};
        //gc.AddGesture("Cross", cross);

        IRelativeGestureSegment[] clap = { new ClapSegment1(), new ClapSegment2() };
        gc.AddGesture("Clap", clap);



        //IRelativeGestureSegment[] turnLeft = { new TurnLeftSegment1(), new TurnLeftSegment2() };
        //gc.AddGesture("TurnLeft", turnLeft);

        //IRelativeGestureSegment[] turnRight = { new TurnRightSegment1(), new TurnRightSegment2() };
        //gc.AddGesture("TurnRight", turnRight);
    }

    void OnGestureRecognized(object sender, GestureEventArgs e)
    {
        if (e.GestureName == "SwipeLeft")
        {
            Debug.Log("SwipeLeft Recognized");
            if (playerAvatar.transform.position.x > -3)
            {
                waveManager.setCurrLane(-1);
                playerAvatar.transform.position += new Vector3(-3, 0, 0);
                playerAvatar.transform.Rotate(0, -35, 0);
            }
            else
            {
                Debug.Log("right border");
            }

        }
        if (e.GestureName == "SwipeRight")
        {
            Debug.Log("SwipeRight Recognized");
            if (playerAvatar.transform.position.x < 3)
            {
                waveManager.setCurrLane(1);
                playerAvatar.transform.position += new Vector3(3, 0, 0);
                playerAvatar.transform.Rotate(0, 35, 0);
            }
            else
            {
                Debug.Log("left border");
            }

        }
        if (e.GestureName == "Clap")
        {
            spellbook.spellCache[0].cast();
            Debug.Log("Clap Recognized");
        }
        if (e.GestureName == "PunchDown")
        {
            spellbook.spellCache[1].cast();
            Debug.Log("PunchDown Recognized");

        }
        if (e.GestureName == "PullUp")
        {
            spellbook.spellCache[2].cast();
            Debug.Log("PullUp Recognized");

        }
        if (e.GestureName == "Circle")
        {
            spellbook.spellCache[3].cast();
            Debug.Log("Circle Recognized");
        }
        //if (e.GestureName == "PullLeft")
        //{
        //    Debug.Log("PullLeft Recognized");
        //}
        //if (e.GestureName == "SwipeLeftBack")
        //{
        //    Debug.Log("SwipeBack Recognized");

        //}
        //if (e.GestureName == "PushFwrd")
        //{
        //    Debug.Log("pushFwrd Recognized");

        //}
        //if (e.GestureName == "Cross")
        //{
        //    Debug.Log("Cross Recognized");
        //}


        //if (e.GestureName == "TurnLeft")
        //{
        //    Debug.Log("TurnLeft Recognized");
        //}
        //if (e.GestureName == "TurnRight")
        //{
        //    Debug.Log("TurnRight Recognized");
        //}

    }

	// Update is called once per frame
	void Update () {
	
	}
}

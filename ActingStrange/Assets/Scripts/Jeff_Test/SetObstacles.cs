using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacles : MonoBehaviour {

    public GameObject lObstacle;    //flat or small obstacles, which doesn't provide shield
    public GameObject obstacle;     //normal obstacles, which provides a little shield
    public GameObject hObstacle;    //huge obstacles, which provide a proper shield

    public int obstacleFactor = 30;

    public int length;
    public int width;               //should be a multiple of 7 

    private int laneWidth;

    void placeObstacles()
    {
        if(width < 7)
        {
            Debug.Log("Width is to narrow");
            return;
        }

        laneWidth = width / 7;
        bool[] pLO = new bool[width];       //array to store the obstacle placement of the previous row
        bool[] cLO = new bool[width];       //array to store the obstacle placement of the current row
        bool[] clear = new bool[width];
        int r;                              //random variable for the placement of obstacles on a lane

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j += laneWidth)
            {
                if (!(i < (length / 8) && !(j == 0 || j == width - laneWidth)))
                {// leave space at the end of the lanes as space for Dr Strange

                    if(j % 2 == 0)
                    {// leave lanes free
                        for (int k = 0; k < laneWidth; k++)
                        {
                            if (j + k < laneWidth || j + k >= width - laneWidth)
                            {// place high obstacles at the left and right borders
                                Instantiate(hObstacle, new Vector3(j + k - (width / 2), 2.5f, i - (length / 2)), Quaternion.identity);
                            }
                            else
                            {// place obstacles to seperate the 3 lanes
                                Instantiate(obstacle, new Vector3(j + k - (width / 2), 0.5f, i - (length / 2)), Quaternion.identity);
                            }
                        }
                    }
                    else if (laneWidth > 1)
                    {
                        for (int k = 0; k < laneWidth; k++)
                        {
                            r = Random.Range(0, 100);

                            if (r < obstacleFactor)
                            {
                                if (k == 0)
                                {
                                    if (!pLO[j + k + 1] || !pLO[j + k + 2])
                                    {
                                        cLO[j + k] = true;
                                        Instantiate(lObstacle, new Vector3(j + k - (width / 2), 0.25f, i - (length / 2)), Quaternion.identity);
                                    }
                                }
                                else if (k == laneWidth - 1)
                                {
                                    if ((!pLO[j + k - 1] && !cLO[j + k - 1]) || (!pLO[j + k - 2] && !cLO[j + k - 2]))
                                    {
                                        cLO[j + k] = true;
                                        Instantiate(lObstacle, new Vector3(j + k - (width / 2), 0.25f, i - (length / 2)), Quaternion.identity);
                                    }
                                }
                                else
                                {
                                    if ((!pLO[j + k - 1] && !cLO[j + k - 1]) || (!pLO[j + k + 1] && !cLO[j + k + 1]))
                                    {
                                        cLO[j + k] = true;
                                        Instantiate(lObstacle, new Vector3(j + k - (width / 2), 0.25f, i - (length / 2)), Quaternion.identity);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            pLO = cLO;
            cLO.Initialize();
        }
    }

	// Use this for initialization
	void Start ()
    {
        placeObstacles();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HulkScript : MonoBehaviour {

    //members
    private string name;
    bool coroutineStarted;
    private int ID;
    private NavMeshAgent agent;
    private Animator animator;
    //enemy attributes
    private float speed;
    private float slow;
    public float damage;
    private bool start = false;
    int lane;
	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(TestCoroutine());
        lane = GameObject.FindObjectOfType<WaveManager>().getCurrLane();

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(1f);
        start = true;
        yield return new WaitForSeconds(20f);
        Destroy(gameObject);
    }

        // Update is called once per frame
    void Update () {
        if (start)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Lane_" + lane);
            GameObject target = null;

            //select nearest
            float maxdistance = 1000000f;

            //findet nächsten enemy und setzt ihn als target
            foreach (GameObject t in targets)
            {
                float distance = Vector3.Distance(t.transform.position, transform.position);

                if (distance <= maxdistance)
                {
                    target = t;
                    maxdistance = distance;
                    if (distance <= 2.5)
                    {
                        animator.SetBool("Attack", true);
                        transform.LookAt(target.transform);
                        if (!coroutineStarted)
                        {
                            coroutineStarted = true;
                            StartCoroutine(DoDamage(target));
                        }
                    }
                    else
                    {
                        coroutineStarted = false;
                        animator.SetBool("Attack", false);
                    }
                }
            }
            //TODO: movement
            agent.SetDestination(target.transform.position);
        }

        else
        {
            transform.position += new Vector3(0.5f,0f,-0.5f) * Time.deltaTime * 4;
        }
    }
    IEnumerator DoDamage(GameObject other)
    {

        while (coroutineStarted)
        {
            other.GetComponent<Enemy>().health -= damage;
            
            yield return new WaitForSeconds(0.5f);
        }

    }
    
}

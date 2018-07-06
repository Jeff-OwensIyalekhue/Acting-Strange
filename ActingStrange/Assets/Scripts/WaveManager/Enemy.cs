using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //members
    private string name;
    private int ID;
    private NavMeshAgent agent;
    private Animator animator;
    //enemy attributes
    public float health;
    private float speed;
    private float slow;
    private float dot;
    private bool start = false;
	// Use this for initialization
	void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        Debug.Log("start couritine");
        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        start = true;
        Debug.Log("back");
    }

        // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (start)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
            GameObject target = null;

            //select nearest
            float maxdistance = 10000000f;

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
                    }
                    else
                    {

                        animator.SetBool("Attack", false);
                    }
                }
            }
            //TODO: movement
            agent.SetDestination(target.transform.position);
        }
    }
}

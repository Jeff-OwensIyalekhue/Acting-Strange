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
    public float attackCd;
    private float currCd;
    public float attackDmg;

    //enemy attributes
    public float health;
    private float speed;
    private float slow;
    private float dot;
    private bool start = false;

    public WaveManager waveManager;
    GameObject target;
    GameObject bot;
    // Use this for initialization
    void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        waveManager = FindObjectOfType<WaveManager>();
        target = GameObject.FindGameObjectWithTag("Player");
        currCd = attackCd;
        //Debug.Log("start couritine");
        StartCoroutine(TestCoroutine());

    }

    IEnumerator TestCoroutine()
    {
        yield return new WaitForSeconds(3.5f);
        start = true;
        //Debug.Log("back");
    }

        // Update is called once per frame
    void Update () {
        if (health <= 0)
        {
            waveManager.killedEnemies(1);
            Destroy(gameObject);
        }
        if (start)
        {
            GameObject[] bots = GameObject.FindGameObjectsWithTag("Bot");

            float maxDistance = Vector3.Distance(target.transform.position, transform.position);
            float distance = maxDistance;

            foreach(GameObject t in bots)
            {
                distance = Vector3.Distance(t.transform.position, transform.position);
                if (distance < maxDistance)
                {
                    target = t;
                    maxDistance = distance;
                }
            }
            

            if (distance <= 2.5)
            {
                animator.SetBool("Attack", true);
                if(currCd<= 0)
                {
                    if (target.tag.Equals("Player"))
                    {
<<<<<<< HEAD
                        animator.SetBool("Attack", true);
                        transform.LookAt(target.transform);
=======
                        waveManager.reduceHealth(attackDmg);    //other setDmg call when attacking !strange
>>>>>>> d628c67573e7625decf9b7e6192bf49ab51fb48e
                    }
                    else
                    {
                        //TODO: attack bot
                    }
                    currCd = attackCd;
                }
                currCd -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("Attack", false);
            }
                
            //TODO: movement
            agent.SetDestination(target.transform.position);
        }
    }
}

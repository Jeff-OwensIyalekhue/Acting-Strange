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
    bool coroutineStarted;
    //enemy attributes
    public float health;
    private float speed;
    private float slow;
    private float dot;
    private bool start = false;

    public WaveManager waveManager;
    GameObject target;
    GameObject bot;

    public AudioSource audioSource;
    public AudioClip[] attackClips;
    public AudioClip[] walkClips;

    // Use this for initialization
    void Start () {
        agent = gameObject.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        waveManager = FindObjectOfType<WaveManager>();
        
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
            target = GameObject.FindGameObjectWithTag("Player");
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
                        animator.SetBool("Attack", true);
                        transform.LookAt(target.transform);
                        coroutineStarted = true;
                        StartCoroutine(DoDamage(target));
                    }
                    else
                    {
                        animator.SetBool("Attack", true);
                        transform.LookAt(target.transform);
                        coroutineStarted = true;
                        StartCoroutine(DoDamage(target));
                    }
                    currCd = attackCd;
                }
                currCd -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("Attack", false);
                coroutineStarted = false;

                if (!audioSource.loop)
                    audioSource.loop = true;
                audioSource.clip = walkClips[Random.Range(0, walkClips.Length)];
                if (!audioSource.isPlaying)
                    audioSource.Play();

            }
                
            //TODO: movement
            agent.SetDestination(target.transform.position);
        }
    }
    IEnumerator DoDamage(GameObject other)
    {
        if (audioSource.loop)
            audioSource.loop = false;

        while (coroutineStarted)
        {
            if (other.tag == "Bot")
            {

                other.GetComponent<PlayerAlliesHealthScript>().health -= attackDmg;
            }
            if (other.tag == "Player")
            {

                waveManager.reduceHealth(attackDmg);
            }

            audioSource.clip = attackClips[Random.Range(0,attackClips.Length)];
            if (!audioSource.isPlaying)
                audioSource.Play();

            yield return new WaitForSeconds(attackCd);
        }
        yield return 0;

    }
}

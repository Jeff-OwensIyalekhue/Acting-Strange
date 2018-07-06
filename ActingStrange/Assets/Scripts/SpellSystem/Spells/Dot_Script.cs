using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Dot_Script : MonoBehaviour {
    private List<GameObject> enemies = new List<GameObject>();
    public float damage;
    private bool coroutineStarted;
    // Use this for initialization
    void Start()
    {
        coroutineStarted = false;
        StartCoroutine(Destroy());

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator DoDamage()
    {
        coroutineStarted = true;
        while (enemies.Count >= 1)
        {
            foreach(GameObject t in enemies)
            {
                t.GetComponent<Enemy>().health -= damage;
                yield return new WaitForSeconds(0.5f);
            }
        }
        coroutineStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            Debug.Log("got_Enemy2");
            enemies.Add(other.gameObject);
            if (!coroutineStarted)
            {
                StartCoroutine(DoDamage());
            }
            other.GetComponent<NavMeshAgent>().speed = other.GetComponent<NavMeshAgent>().speed * 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Lane_1" || other.tag == "Lane_2" || other.tag == "Lane_3")
        {
            Debug.Log("got_Enemy3");
            if (enemies.Contains(other.gameObject))
            {
                enemies.Remove(other.gameObject);
            }
        }
    }
}

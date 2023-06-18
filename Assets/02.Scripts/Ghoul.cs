using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghoul : MonoBehaviour
{
    public Transform player;
    public Vector3 specificPosition;

    private NavMeshAgent agent;

    public GameObject Bgm;
    public GameObject Bgm2;
    AudioSource _audioSource;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(_audioSource.clip.name);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= 60f)
        {
            agent.SetDestination(player.position);
            FaceTarget(player.position);
        }
        else
        {
            agent.SetDestination(specificPosition);
            FaceTarget(specificPosition);
        }

        if(distanceToPlayer <= 20f)
        {
            _audioSource.Play(_audioSource.clip);
            Bgm.SetActive(false);
            Bgm2.SetActive(true);
        }
    }

    void FaceTarget(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Ending");
        }
    }
}

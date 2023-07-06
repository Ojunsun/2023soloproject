using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Ghoul : MonoBehaviour
{
    public Transform player;
    public Vector3 specificPosition;

    float extraRotationSpeed = 5f;
    private NavMeshAgent agent;

    public GameObject Bgm;
    public GameObject Bgm2;
    AudioSource _audioSource;
    private bool isFirst = true;

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
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);

        if (distanceToPlayer <= 100f)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.SetDestination(specificPosition);
        }

        if(distanceToPlayer <= 20f)
        {
            if(isFirst)
            {
                _audioSource.Play();
                isFirst = false;
            }
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

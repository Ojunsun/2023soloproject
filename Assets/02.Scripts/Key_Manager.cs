using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key_Manager : MonoBehaviour
{
    public GameObject[] keys;
    public GameObject door;
    public GameObject Player;

    private GameObject activeKey;
    private bool hasKey = false;

    void Start()
    {
        // Activate a random key object
        int randomIndex = Random.Range(0, keys.Length);
        activeKey = keys[randomIndex];
        activeKey.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (!hasKey && activeKey != null && Vector3.Distance(Player.transform.position, activeKey.transform.position) < 4f)
            {
                ObtainKey();
            }
            else if (hasKey && door != null && Vector3.Distance(Player.transform.position, door.transform.position) < 4f)
            {
                OpenDoor();
            }
        }
    }

    void ObtainKey()
    {
        Debug.Log("키를 얻었다우");
        hasKey = true;
        activeKey.SetActive(false);
    }

    void OpenDoor()
    {
        SceneManager.LoadScene("Clear");
    }
}

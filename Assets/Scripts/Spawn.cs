using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
    }
}

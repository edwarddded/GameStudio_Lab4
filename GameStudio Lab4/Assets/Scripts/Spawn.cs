using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Enemy;

    public GameObject[] EnemyPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemyPrefabs[10], Enemy.position, Enemy.rotation);

    }
  
    // Update is called once per frame
    void Update()
    {
        //if ()
        //{

        //}
    }
}

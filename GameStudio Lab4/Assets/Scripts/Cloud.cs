using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject cloudL;
    public GameObject cloudM;
    public GameObject cloudS;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateCloud", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (cloudL.transform.position.y < -6.7)
        {
            Destroy(cloudL);
        }
    }
    public void CreateCloud()
    {
        Instantiate(cloudL, new Vector3 (-6.5f, 4f, 1f), Quaternion.identity);
        Instantiate(cloudM, new Vector3(7.5f, 2.5f, 1f), Quaternion.identity);
        Instantiate(cloudS, new Vector3(0.5f, 3.5f, 1f), Quaternion.identity);
    }
}

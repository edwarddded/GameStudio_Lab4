using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarSweeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 3f);
        if (this.gameObject.transform.position.y > 8)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}

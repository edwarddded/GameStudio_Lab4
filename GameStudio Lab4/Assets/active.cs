using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active : MonoBehaviour
{
    public GameObject EnemyPrefab;
    //Singleton
    private static active m_Instance = null;
    public static active Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = (active)FindObjectOfType(typeof(active));
            }
            return m_Instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

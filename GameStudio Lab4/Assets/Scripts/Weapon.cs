using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject BulletPrefabs;
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    // Update is called once per frame
    private void Start()
    {
        AudioSource.clip = AudioClip;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
            AudioSource.Play();
        }
    }
    void shoot()
    {
        Instantiate(BulletPrefabs, FirePoint.position, FirePoint.rotation);
    }
}

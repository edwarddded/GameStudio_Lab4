using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 50f;
    
    public GameObject bar;
    // Start is called before the first frame update
    void Start()
    {
        AnimateBar();
    }
    public void AnimateBar()
    {
        LeanTween.scaleX(bar, 0, timer);
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <0f)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}

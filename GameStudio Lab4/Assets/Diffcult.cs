using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diffcult : MonoBehaviour
{
    public Patrol pt;
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void Level1()
    {
        pt.speed = 5;
    }
    public void Level2()
    {
        pt.speed = 4;
    }
    public void Level3()
    {
        pt.speed = 3;
    }
    public void Level4()
    {
        pt.speed = 2;
    }
    public void Level5()
    {
        pt.speed = 1;
    }
}

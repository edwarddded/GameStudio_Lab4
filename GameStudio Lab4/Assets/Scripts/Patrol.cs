using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Patrol : MonoBehaviour
{
    //GameManager, this object will be called to handle score and enemy spawning
    public GameObject gcObject;
    public GameController gc;

    public float speed;
    private float WaitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float life;
    public GameObject parachute;

    // Start is called before the first frame update
    void Start()
    {
        gcObject = GameObject.FindGameObjectWithTag("GameController");

        if(gcObject != null)
        gc = gcObject.GetComponent<GameController>();

        WaitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        
    }
    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpot.position) < 2f)
        {
            if (WaitTime <=0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                WaitTime = startWaitTime;
            }
            else
            {
                WaitTime -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (gcObject != null && gc != null) {
            if (collision.gameObject.tag == "Bullet")
            {
                gc.AddToScore();
                Destroy(collision.gameObject);
                life = life - 1;

                if (life <= 0)
                {
                    gc.enemyDestroyed();
                    Destroy(this.gameObject);

                    GameObject parachute1 = (GameObject)(Instantiate(parachute, gameObject.transform.position, Quaternion.identity));

                    Destroy(parachute1, 1);

                }

            }
        }
    }
}

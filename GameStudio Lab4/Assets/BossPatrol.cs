using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossPatrol : MonoBehaviour
{
    public float bspeed;
    private float bWaitTime;
    public float bstartWaitTime;

    public Transform bmoveSpot;
    public float bminX;
    public float bmaxX;
    public float bminY;
    public float bmaxY;

    //public Animator enemyani;
    public Text btext;
    public float bscore;

    // Start is called before the first frame update
    void Start()
    {
        bWaitTime = bstartWaitTime;
        bmoveSpot.position = new Vector2(Random.Range(bminX, bmaxX), Random.Range(bminY, bmaxY));

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, bmoveSpot.position, bspeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, bmoveSpot.position) < 2f)
        {
            if (bWaitTime <= 0)
            {
                bmoveSpot.position = new Vector2(Random.Range(bminX, bmaxX), Random.Range(bminY, bmaxY));
                bWaitTime = bstartWaitTime;
            }
            else
            {
                bWaitTime -= Time.deltaTime;
            }
        }
        if (bscore > 17)
        {
            SceneManager.LoadScene(3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            playerbscore();
            if (bscore < 14)
            {
                GameObject enemy = (GameObject)(Instantiate(gameObject, new Vector2(0.3f, 1.66f), Quaternion.identity));
                enemy.GetComponent<SpriteRenderer>().flipY = true;
                enemy.GetComponent<Patrol>().enabled = true;
                enemy.GetComponent<CircleCollider2D>().enabled = true;
            }
            

        }


    }
    void playerbscore()
    {
        bscore++;
        btext.text = "Score:" + bscore.ToString();

    }

}

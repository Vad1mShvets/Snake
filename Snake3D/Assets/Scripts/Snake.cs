using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    int score;

    public GameObject tail;
    public GameObject apple;
    public GameObject gameOverPanel;

    bool isDead = false;

    float x, z;
    float speed;

    public Text txtScore;

    private void Start()
    {
        speed = 0.035f;
    }

    private void FixedUpdate()
    {
        if (isDead == false)
        {
            this.transform.Translate(x, 0, z);
        }
    }

    private void Update()
    {
       
        txtScore.text = score * 75 + "";

        #region Controls
        if (Input.GetKeyDown("a"))
        {
            Left();
        }
        if (Input.GetKeyDown("d"))
        {
            Right();
        }
        if (Input.GetKeyDown("w"))
        {
            Up();
        }
        if (Input.GetKeyDown("s"))
        {
            Down();
        }
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("apple"))
        {
            Destroy(other.gameObject);
            score++;
            GameObject tailSpawn = Instantiate(tail);
            tailSpawn.name = score + 5 + "";

            SpawnApple();
        }

        if (other.tag == "Tail" || other.name.Contains("wall"))
        {
            Death();
        }
    }

    void SpawnApple()
    {
        GameObject appleSpawn = Instantiate(apple);
        appleSpawn.transform.position = new Vector3(Random.Range(-4, 4), 0.15f, Random.Range(-4, 4));
    }

    void Death()
    {
        isDead = true;
        gameOverPanel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void Up()
    {
        x = 0;
        z = speed;
    }
    public void Down()
    {
        x = 0;
        z = -speed;
    }
    public void Left()
    {
        x = -speed;
        z = 0;
    }
    public void Right()
    {
        x = speed;
        z = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public enum State
    {
        ALIVE, DEAD
    }

    public State playerState = State.ALIVE;
    public int maxHealth;
    private int health;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int damage)
    {
        if (playerState == State.ALIVE)
        {
            health -= damage;
            Debug.Log("HURT");
            if (health <= 0)
            {
                Debug.Log("DIE");
                SceneManager.LoadScene("Lab", LoadSceneMode.Single);
                Die();
            }
        }
    }

    void Die()
    {

    }
}
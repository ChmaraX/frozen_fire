using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private ItemCollector itemCollector;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemCollector = GetComponent<ItemCollector>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Trap"))
        {
            if (itemCollector.collectedHPs > 0)
            {
                itemCollector.decreaseHPsBy(1);
                Debug.Log("Life lost");
                //TODO: return to checkpoint?
                RestartLevel();
            }
            else
            {
                Die();
            }  
        }
    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        // add trigger do death animation

        Debug.Log("Player died");
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

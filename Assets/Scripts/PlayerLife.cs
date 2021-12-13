using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private ItemCollector itemCollector;
    private PlayerMovement playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        itemCollector = GetComponent<ItemCollector>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string CollidingObjectTag = collision.gameObject.tag;
        // if colliding object is of type Fire|Ice Trap -> collide regardless of side
        if (CollidingObjectTag.Contains("FireTrap") || CollidingObjectTag.Contains("IceTrap"))
        {
            HandleCollision(collision);
        } 
        // if not Fire|Ice & Trap is collided on the side
        else if (CollidingObjectTag.Contains("Trap") && collision.collider.GetType() == typeof(EdgeCollider2D)) 
        {
            HandleCollision(collision);
        }
    }

    private void HandleCollision(Collision2D collision) 
    {
        if (itemCollector.collectedHPs > 0)
        {
            itemCollector.decreaseHPsBy(1);
            Debug.Log("Life lost");

            // return to last checkpoint
            HandleCheckpoint();
        }
        else
        {
            Die();
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

    private void HandleCheckpoint()
    {
        Vector3 lastCheckpointPos = itemCollector.lastCheckpointPos;

        // move player to last checkpoint position
        transform.position = lastCheckpointPos;
        playerMovement.moveSpeed = 0;

        // wait for 2 seconds till player gets ready to continue
        StartCoroutine(Wait(2));

    }

    private IEnumerator Wait(int secs)
    {
        yield return new WaitForSeconds(secs);
        // restore movement speed back to normal
        playerMovement.moveSpeed = 7f;
    }
}

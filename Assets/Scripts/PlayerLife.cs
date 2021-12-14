using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private ItemCollector itemCollector;
    private PlayerMovement playerMovement;

    [SerializeField] GameObject respawnEffect;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject lifeLossEffect;

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
        Instantiate(deathEffect,
            new Vector3(
                transform.position.x,
                transform.position.y + 1,
                transform.position.z),
            Quaternion.identity);

        playerMovement.moveSpeed = 0;
        StartCoroutine(WaitAndRestart(1.5f));
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

        Instantiate(lifeLossEffect,
            new Vector3(
                transform.position.x,
                transform.position.y + 2,
                transform.position.z),
            Quaternion.identity);

        Instantiate(respawnEffect,
            new Vector3(
                transform.position.x,
                transform.position.y - 1,
                transform.position.z),
            Quaternion.Euler(-90f, 0f, 0f));

        // wait for 2 seconds till player gets ready to continue
        StartCoroutine(WaitAndResume(2));

    }

    private IEnumerator WaitAndResume(float secs)
    {
        yield return new WaitForSeconds(secs);
        // restore movement speed back to normal
        playerMovement.moveSpeed = 7f;
    }

    private IEnumerator WaitAndRestart(float secs)
    {
        yield return new WaitForSeconds(secs);
        RestartLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerLife : MonoBehaviour
{
    public ItemCollector itemCollector {get; private set;}
    private PlayerMovement playerMovement;
    private GameObject levelEnd;

    [SerializeField] GameObject respawnEffect;
    [SerializeField] GameObject deathEffect;
    [SerializeField] GameObject lifeLossEffect;

    private void Start()
    {
        itemCollector = GetComponent<ItemCollector>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string CollidingObjectTag = collision.gameObject.tag;
        string[] OneSideCollidable = { "FireTrap", "IceTrap", "SawTrap" };

        // if colliding object is of type Fire|Ice Trap -> collide regardless of side
        if (Array.IndexOf(OneSideCollidable, CollidingObjectTag) > -1)
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

        SoundManagerScript.PlaySound("playerDeath");

        playerMovement.moveSpeed = 0;

        levelEnd = GameObject.FindWithTag("LevelEnd");
        levelEnd.GetComponent<LevelEndController>().ShowGameOver(this);
    }

    public void HandleCheckpoint()
    {
        Vector3 lastCheckpointPos = new(
            itemCollector.lastCheckpointPos.x,
            itemCollector.lastCheckpointPos.y,
            itemCollector.lastCheckpointPos.z - 0.1f
        );

        // replace inventory with most recent item snapshot
        ReplaceInventoryWithSnapshot();

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

        SoundManagerScript.PlaySound("respawn");

        // wait for 2 seconds till player gets ready to continue
        StartCoroutine(WaitAndResume(2));

    }

    private void ReplaceInventoryWithSnapshot()
    {
        List<IInventoryItem> itemsSnap = itemCollector.itemsSnap;
        itemCollector.inventory.ClearInventory();

        foreach (IInventoryItem item in itemsSnap)
        {
            itemCollector.inventory.AddItem(item);
        }
    }

    private IEnumerator WaitAndResume(float secs)
    {
        yield return new WaitForSeconds(secs);
        // restore movement speed back to normal
        playerMovement.moveSpeed = 7f;
    }
}

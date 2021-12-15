using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] Vector3 spawnPosition;

    private GameObject player;

    private void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z), Quaternion.identity);
    }

    void Update()
    {
        // focus camera on player and keep own Z position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);
    }
}

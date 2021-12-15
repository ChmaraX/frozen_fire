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
        player = Instantiate(playerPrefab, new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z - 1), Quaternion.identity);
    }

    void Update()
    {

        // focus camera on player and keep own Z position
        float y_pos = 0.3f * player.transform.position.y;
        Vector3 target = new Vector3(player.transform.position.x, y_pos + 1, -10);
        transform.position = target;
    }

}

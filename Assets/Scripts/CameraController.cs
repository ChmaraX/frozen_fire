using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private GameObject player;

    private void Start()
    {
        player = Instantiate(playerPrefab, new Vector3(gameObject.transform.position.x - 3, gameObject.transform.position.y, 0), Quaternion.identity);
    }

    void Update()
    {
        // focus camera on player and keep own Z position
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);
    }
}

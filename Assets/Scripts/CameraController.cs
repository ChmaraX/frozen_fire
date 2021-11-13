using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    void Update()
    {
        // focus camera on player and keep own Z position
        transform.position = new Vector3(player.position.x, player.position.y * 0.25f, transform.position.z);
    }
}

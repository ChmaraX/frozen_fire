using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip
        playerFireSound,
        respawnSound,
        chestOpenSound,
        checkpointPickSound,
        playerJumpSound,
        playerDeathSound,
        victorySound,
        itemPickSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerFireSound = Resources.Load<AudioClip>("playerFireSound");
        playerJumpSound = Resources.Load<AudioClip>("playerJumpSound");
        playerDeathSound = Resources.Load<AudioClip>("playerDeathSound");

        victorySound = Resources.Load<AudioClip>("victorySound");

        itemPickSound = Resources.Load<AudioClip>("itemPickSound");
        respawnSound = Resources.Load<AudioClip>("respawnSound");
        chestOpenSound = Resources.Load<AudioClip>("chestOpenSound");
        checkpointPickSound = Resources.Load<AudioClip>("checkpointPickSound");
        
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch(clip)
        {
            case "playerFire":
                audioSrc.PlayOneShot(playerFireSound);
                break;
            case "playerJump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "playerDeath":
                audioSrc.PlayOneShot(playerDeathSound);
                break;
            case "itemPick":
                audioSrc.PlayOneShot(itemPickSound);
                break;
            case "respawn":
                audioSrc.PlayOneShot(respawnSound);
                break;
            case "chestOpen":
                audioSrc.PlayOneShot(chestOpenSound);
                break;
            case "checkpointPick":
                audioSrc.PlayOneShot(checkpointPickSound);
                break;
            case "victory":
                audioSrc.PlayOneShot(victorySound);
                break;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacoAttack : MonoBehaviour
{
    public Transform fireballSpawn;
    public GameObject fireball;

    private GameObject player;

    private Vector3 dir; 

    public AudioSource aud; 

    // Start is called before the first frame update

    public AudioClip[] audioClips;

    // Use this for initialization
    void Start()
    {
        aud = this.GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void attack()
    {
        //Play sound effect
        aud.clip = audioClips[Random.Range(0, audioClips.Length)];
        aud.Play();

        Instantiate(fireball, fireballSpawn.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    LayerMask enemyMask;

    public int weaponDamage = 7; 

    Camera mainCamera;

    public AudioSource aud;
    public AudioClip[] audioClips;

    public Animator anim;
    public GameObject WeaponObject;

    public GameObject explosion; 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Camera>();
        enemyMask = LayerMask.GetMask("Enemy");
        aud = this.GetComponent<AudioSource>();
        anim = WeaponObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && anim.GetBool("fired") == false)
        {
            anim.SetBool("fired", true);
            aud.clip = audioClips[Random.Range(0, audioClips.Length)];
            aud.Play();
            Debug.Log("Fired");
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 5);
            //Fired
            if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, Mathf.Infinity, enemyMask))
            {
                hit.collider.gameObject.GetComponentInParent<Enemy2Behaviour>().takeDamage(weaponDamage);
                Debug.Log("hit an enemy");
                //Play explosion effect
                Instantiate(explosion, hit.point, Quaternion.identity);
            } 
        }
        //anim.SetBool("fired", false);
    }
}

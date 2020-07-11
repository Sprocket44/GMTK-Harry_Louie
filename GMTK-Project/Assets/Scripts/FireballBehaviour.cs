using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{

    public float projectileSpeed = 3;

    public GameObject target;

    GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Deal Damage to player
        player.GetComponent<PlayerStats>().takeDamage(5);
        Destroy(this.gameObject);
    }
}

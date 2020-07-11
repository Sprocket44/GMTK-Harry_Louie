using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject camera; 

    public int playerHealth; 

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 60;
    }

    // Update is called once per frame
    void Update()
    {
        changeFOV(); 
    }

    void changeFOV()
    {
        camera.GetComponent<Camera>().fieldOfView = playerHealth; 
    }
}

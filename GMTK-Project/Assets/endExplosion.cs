using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endExplosion : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim; 
    void Start()
    {
        //anim = this.GetComponent<Animator>(); 
        //anim.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void end()
    {
        Destroy(this.gameObject);
    }
}

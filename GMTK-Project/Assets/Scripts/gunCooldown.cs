using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunCooldown : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        anim.SetBool("fired", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRise : MonoBehaviour
{
    public GameObject Water;
    public GameObject Ice;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        while(i < 100)
        {
            i++;
            animator.Play("WaterRise");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

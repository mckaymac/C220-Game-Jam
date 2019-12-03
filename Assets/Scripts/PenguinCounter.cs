using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinCounter : MonoBehaviour
{
    public int Penguins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Penguins = GameObject.FindGameObjectsWithTag("Penguin").Length;
    }
}

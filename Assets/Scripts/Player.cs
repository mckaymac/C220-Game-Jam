using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int SavedPenguins;
    public int KilledPenguins;
    public int Money;
    public GameObject MoneyObject;
    public GameObject KarmaObject;
    public int Karma;
    // Start is called before the first frame update
    void Start()
    {
        SavedPenguins = 0;
        KilledPenguins = 0;
        Money = 0;
    }

    public void KilledPenguin(){
        KilledPenguins += 1;
        Money += 200;
        MoneyObject.GetComponent<Text>().text = "$" + Money;
    }

    public void SavedPenguin(){
        SavedPenguins += 1;
        Karma += 50;
        KarmaObject.GetComponent<Text>().text = "Karma: " + Karma;
    }
}

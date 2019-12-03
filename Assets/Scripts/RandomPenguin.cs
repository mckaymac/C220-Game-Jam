using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPenguin : MonoBehaviour
{
    //Used to generate which direction the penguin goes
    Random rand = new Random();

    //How often the penguin should move, counter is used to count up to Cycle
    private int Cycle = 120;
    private int counter;

    //Used for distance to player for text that pops up
    public GameObject Player;
    private float Distance;
    public GameObject CommandKey;
    public GameObject Command;

    //Used to trigger animations for the pengiun
    private Animator Animator;
    
   

    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        counter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;
        if(counter >= Cycle){
            gameObject.transform.position += new Vector3(1, 0, 0);

        }
    }

    void Update(){
        //Calculating distance between door and player
        var xDiff = gameObject.transform.position.x - Player.transform.position.x;
        var zDiff = gameObject.transform.position.z - Player.transform.position.z;
        Distance = Mathf.Pow(Mathf.Pow(xDiff, 2) + Mathf.Pow(zDiff, 2), (float) 0.5);
    }

    void OnMouseOver(){
        //When within 2 units, show door instructions and allow them to teleport
        if(Distance < 2){
            //Showing the texts on canvas and changes the text
            Command.GetComponent<Text>().text = "Rescue Penguin";
            CommandKey.SetActive(true);
            Command.SetActive(true);
            if(Input.GetButtonDown("Action") ){
                //Triggers animations and disables the box collider
            }
        }
        else{
            CommandKey.SetActive(false);
            Command.SetActive(false);
        }    
    }
}

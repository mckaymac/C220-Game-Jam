using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RandomPenguin : MonoBehaviour
{
    //Used to generate which direction the penguin goes
    System.Random rand = new System.Random();
    Vector3 Direction = new Vector3(0,0,0);

    //How often the penguin should move, counter is used to count up to Cycle
    private int Cycle = 120;
    private int counter;

    //Used for distance to player for text that pops up
    public GameObject Player;
    public float Distance;
    public GameObject CommandKey;
    public GameObject Command;

    //Used to trigger animations for the pengiun
    private Animator Animator;
    private Rigidbody Rigidbody;

    //Stuff for penguin physics
    public float movementSpeed = 3;
    private bool Moving = false;
    
   

    // Start is called before the first frame update
    void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
        counter = 0;
        Direction = new Vector3(rand.Next(180), 0, rand.Next(180));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Walking animation triggered while moving
        if(Moving){
            Animator.SetInteger("Walk", 1);
        }
        else{
            Animator.SetInteger("Walk", 0);
        }
        
        counter += 1;
        if(counter >= Cycle){
            Moving = true;

            //Face random direction, only do this once per movement
            if(counter == Cycle){
                gameObject.transform.Rotate(new Vector3(0, rand.Next(0, 360),0), Space.World);
            }
            
            //Move a little each update given the random direction
            gameObject.transform.position += gameObject.transform.forward / 25;
            
            //gameObject.transform.Translate(Direction, Space.World);

        }
        else{
            Moving = false;
        }

        if(counter == 2 * Cycle){
            counter = 0;
        }

    }

    void Update(){
        //Calculating distance between penguin and player
        var xDiff = gameObject.transform.position.x - Player.transform.position.x;
        var zDiff = gameObject.transform.position.z - Player.transform.position.z;
        Distance = Mathf.Pow(Mathf.Pow(xDiff, 2) + Mathf.Pow(zDiff, 2), (float) 0.5);
    }


    void OnMouseOver(){
        //When within 2 units, show door instructions and allow them to teleport
        if(Distance < 4){
            //Showing the texts on canvas and changes the text
            Command.GetComponent<Text>().text = "Rescue Penguin";
            CommandKey.GetComponent<Text>().text = "[E]";
            CommandKey.SetActive(true);
            Command.SetActive(true);
            if(Input.GetButtonDown("Action") ){
                Destroy(gameObject);
                CommandKey.SetActive(false);
                Command.SetActive(false);
                //Probably add something here the decreases the meter
            }
        }
        else{
            CommandKey.SetActive(false);
            Command.SetActive(false);
        }    
    }
}

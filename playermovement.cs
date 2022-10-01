using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{ 
    public CharacterController controler;
     //variable for speed
    public float speed  = 12f;
    Vector3 velocity;
    //variable for gravity
    public float gravity = -9.8f;
    //position at which we add empty object in unity for check
    public Transform groundcakae;
    //jumphight for not jumping again
    public float grounddistance = 0.4f;
    //layer to find ground for player
    public LayerMask groundmask;
    //bool for is ground
    bool isground ;
    //power of jump
    public float jumphight = 3f;
    //things you can change          {
    public GameObject panal;
    public TextMeshProUGUI FINALTEXT;
    //                               }

    // Start is called before the first frame update
    void Start()
    {//turning off text so it cant show in starting of game
        FINALTEXT.enabled=false;
    }

    // Update is called once per frame
    void Update()
    { //creating a invisible sphere for finding ground
      isground = Physics.CheckSphere(groundcakae.position,grounddistance,groundmask);
       
       if (isground && velocity.y<0)
       {
          velocity.y = -2f;
       }//for jump
       if (Input.GetButtonDown("Jump") && isground)
       {
          velocity.y = Mathf.Sqrt(jumphight*-2f*gravity);
       }
        //for side to side movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right*x+transform.forward*z;
        controler.Move(move*speed*Time.deltaTime);
        velocity.y += gravity*Time.deltaTime;
        controler.Move(velocity*Time.deltaTime);

    }//for finding what is colliding
    // end after this line you can cange any thing
    public void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.tag == "ground")
      {
        end2();
      }
    }
    public void end()
    {
      FindObjectOfType<seenmanager>().restart();
    }
    public void end2()
    {
        Invoke("end",1f);
         panal .SetActive(true);
     Debug.Log("YOU ARE NOT THE CHOICENONE");
     FINALTEXT.enabled = true;
    }
    public void end3()
    {
      
        Invoke("end",1f);
         panal .SetActive(true);
     Debug.Log("that a wrong one");
     FINALTEXT.text = "THAT A WRONG ONE";
     FINALTEXT.enabled = true;
    }
}

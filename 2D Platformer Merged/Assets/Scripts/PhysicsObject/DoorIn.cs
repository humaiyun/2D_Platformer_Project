﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIn : MonoBehaviour
{
   
    private bool first = false;
    public GameObject door1;
    public GameObject door2;
    private Animator door;

    // Start is called before the first frame update
    void Start()
    {
       // door1 = GameObject.Find("House Interior");
      //  door2 = GameObject.Find("ExteriorScene");
      door = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

        private void OnTriggerStay2D(Collider2D collision) 
    {
          

        if (Input.GetKey(KeyCode.E) && !first)
        {
             first = true;
         FindObjectOfType<PlayerController>().canMove=false;
                FindObjectOfType<PlayerController>().canFlip=false;
            door.SetBool("open", true);
           
                StartCoroutine(Test());
    
        
              //  door1.SetActive(false);
             //   door2.SetActive(true);
                
   
        }
    }

    private void OnTriggerExit2D( Collider2D collision ) {
              FindObjectOfType<PlayerController>().canMove=true;
                FindObjectOfType<PlayerController>().canFlip=true;
                  first = false;
                 
    }

     IEnumerator Test()
    {
        
        yield return new WaitForSeconds(0.3f);
        door.SetBool("open", false);
         door.SetBool("done", true);
                door1.SetActive(false);
                door2.SetActive(true);
        
    
    }
}

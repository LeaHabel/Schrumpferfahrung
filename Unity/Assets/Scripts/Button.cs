using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using shrink.project.de;
using UnityEngine;


public class Button : MonoBehaviour
{
    BoxCollider hitbox;
    GameObject player;
    Camera player_camera;
    Vector3 playerPosition;
    Vector3 buttonPosition;
    double playerDistance = 0.0;
    bool isBusy;
    ShrinkOrGrow playerShrinkscript, environmentShrinkscript;
    public ParticleSystem beam;
    public GameObject growableEnvironment;
    AudioSource beamAudio;

    public PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        hitbox = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        isBusy = false;
        buttonPosition = this.transform.position;
        Console.WriteLine("buttons position is: " + buttonPosition.ToString());

        playerShrinkscript = player.GetComponent<ShrinkOrGrow>();
        environmentShrinkscript = growableEnvironment.GetComponent<ShrinkOrGrow>();
        player_camera = player.GetComponentInChildren<Camera>();
        beamAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;

        //get distance between button and player
        playerDistance = Vector3.Distance(playerPosition, buttonPosition);
        Console.WriteLine("player/button distance is: %d", playerDistance);

        //start shrink beam if player is close enough and presses the action button
        if (playerDistance <= 2 && Input.GetKeyDown("e"))
        {
            beam.Play();
            beamAudio.Play(0);

            playerController = player.GetComponent<shrink.project.de.PlayerController>();
            //playerController.canMove = false;

            playerShrinkscript.shrink();
            //player_camera.fieldOfView = 120;

           
            

            playerController.speed_vertical =  Mathf.SmoothStep(playerController.speed_vertical, 0.5f, 5000);
            playerController.speed_horizontal = Mathf.SmoothStep(playerController.speed_horizontal, 0.5f, 5000);
            //player.GetComponent<ConstantForce>().force = new Vector3(0,0.2f,0) ;
            


            //player_camera.aspect = 12/9f;
            //environmentShrinkscript.grow();
        }
    }


}

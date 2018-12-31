using System;
using System.Collections;
using System.Collections.Generic;
using shrink.project.de;
using UnityEngine;

public class Button : MonoBehaviour
{
    BoxCollider hitbox;
    GameObject player;
    Vector3 playerPosition;
    Vector3 buttonPosition;
    double playerDistance = 0.0;
    bool isBusy;
    ShrinkOrGrow playerShrinkscript;
	GameObject box;
	public ParticleSystem beam;

    // Use this for initialization
    void Start()
    {
        hitbox = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
        isBusy = false;
        buttonPosition = this.transform.position;
        Console.WriteLine("buttons position is: " + buttonPosition.ToString());

        playerShrinkscript = player.GetComponent<ShrinkOrGrow>();

		box = GameObject.FindGameObjectWithTag("Box");

    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;

        //get distance between button and player
        playerDistance = Vector3.Distance(playerPosition, buttonPosition);
        Console.WriteLine("player/button distance is: %d", playerDistance);

        //start shrink beam if player is close enough and presses the action button
        if (playerDistance <= 5 && Input.GetKeyDown("e"))
        {
            isBusy = true;
			beam.Play();
            playerShrinkscript.shrink();
            isBusy = false;

			box.GetComponent<ShrinkOrGrow>().shrink();
        }
    }
}

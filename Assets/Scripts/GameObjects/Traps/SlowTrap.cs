﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SlowTrap : TrapDefense
{
    [SyncVar]
    bool isActive = false;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CmdTriggerTrap();

            if (isActive)
            {
                other.GetComponent<Movement>().IsSlowed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isActive)
        {
            other.GetComponent<Movement>().IsSlowed = false;
        }
    }

    [Command]
    private void CmdTriggerTrap()
    {
        isActive = true;
        GetComponentInChildren<Renderer>().enabled = true;
    }
}
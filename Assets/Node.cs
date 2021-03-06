﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color startColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private GameObject turret;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if(turret != null)
        {

            return;
        }


        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();

        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}

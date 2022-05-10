﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine;

public class Case
{
    public GameObject caseCube;

    public CaseType.TerrainType typeRegion;
    //private int tabX;
    //private int tabY;

    private Vector2 tabRef;
    private Vector3 position;

    public float altitude = 60f;
    
    //private GameObject personnage;

    public Case( CaseType.TerrainType region, float currentHeight, int x, int y, GameObject obj)
    {
        typeRegion = region;
        
        caseCube = obj;

        tabRef.x = x;
        tabRef.y = y;

        float height;  //Hauteur de la surface du cube
        
        //float height = region.height * altitude;

        if (typeRegion.name.Equals("Water"))
        {
            height = 0.4f * Constants.altitude;
        }
        else
        {
            height = currentHeight * Constants.altitude;
            //height = region.height * altitude;
        }

        position = new Vector3();
        position.x = (tabRef.x * Constants.CaseSize) - Constants.MapWidth * Constants.CaseSize / 2 + Constants.CaseSize / 2;
        position.y = height / 2;
        position.z = (tabRef.y * Constants.CaseSize) - Constants.MapHeight * Constants.CaseSize / 2 + Constants.CaseSize / 2;

        caseCube.transform.position = position;

        caseCube.transform.localScale = new Vector3(Constants.CaseSize, height, Constants.CaseSize);
        
        obj.GetComponent<MeshRenderer>().material.color = region.colour;

        obj.GetComponent<BlockCase>().tabRef = tabRef;
    }

    
}

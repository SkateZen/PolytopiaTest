using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauJeu : MonoBehaviour
{
    public GameObject terrain;

    public MapGenerator mapGen;

    public GameObject newPlane;
    
    public Case[,] grid;

    public Personnage player;

    private bool validate = false;
    public int level;

    void Start()
    {
        int size = 0;

        if (level == 0)
        {
            size = Constants.MapSize_1;
        }
        else if (level == 1)
        {
            size = Constants.MapSize_2;
        }
        print(size);
        
            
        grid = new Case[size, size];
        print(grid.Length);
        
        //InitPlateauJeu();
        mapGen.Generate3dMap(true, level);
        
        //limite.InitLimite();
        
    }

    private void Update()
    {
        //print("bool=");
        //print(level);
        //print(player.exit);
        if (player.exit && !validate)
        {
            print("second level");
            validate = true;
            //CleanTerrain();
            terrain.SetActive(false);
            
            newPlane.SetActive(true);
            gameObject.SetActive(false);

            player.GetComponent<Personnage>().plateau = newPlane.GetComponent<PlateauJeu>();

            /*if (level == 1)
            {
                grid.Initialize();
                print(grid);
                grid = new Case[Constants.Map_2, Constants.Map_2];
                //print(grid);
            }
            mapGen_1.Generate3dMap(true, level);*/
        }
    }
    
    public void CleanTerrain()
    {
        
        DestroyImmediate(GameObject.FindGameObjectWithTag("CaseCube"));
    }

    public void SetPlateau()
    {
        
    }
}

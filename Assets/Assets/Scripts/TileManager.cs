﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    #region Properties
    private static TileManager instance;

    public GameObject[] tilePrefabs;
    public GameObject currentTile;

    private Stack<GameObject> leftTiles;
    private Stack<GameObject> topTiles;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }

            return instance;
        }
    }

    public Stack<GameObject> LeftTiles
    {
        get
        {
            return leftTiles;
        }

        set
        {
            leftTiles = value;
        }
    }

    public Stack<GameObject> TopTiles
    {
        get
        {
            return topTiles;
        }

        set
        {
            topTiles = value;
        }
    }
    #endregion

    // Use this for initialization
    void Start()
    {
        leftTiles = new Stack<GameObject>();
        topTiles = new Stack<GameObject>();

        CreateTiles(20);

        for (int i = 0; i < 20; i++)
        {
            SpawnTile();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateTiles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));

            topTiles.Peek().name = "TopTile";
            topTiles.Peek().SetActive(false);

            leftTiles.Peek().name = "LeftTile";
            leftTiles.Peek().SetActive(false);
        }
    }

    public void SpawnTile()
    {
        if (leftTiles.Count == 0 || topTiles.Count == 0)
        {
            CreateTiles(10);
        }

        int randomIndex = Random.Range(0, tilePrefabs.Length);

        if (randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if (randomIndex == 1)
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }

        int spawnerPickup = Random.Range(0, 10);
        if (spawnerPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}

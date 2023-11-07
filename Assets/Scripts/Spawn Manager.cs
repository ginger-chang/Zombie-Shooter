using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnLocations;
    public float spawnTime;
    public GameObject monsterPrefab;
    public GameObject player;

    public void Spawn()
    {
        Transform spawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
        GameObject monster = Instantiate(monsterPrefab, spawn.position, spawn.rotation);
        monster.GetComponent<Monster>().player = player;
        monster.GetComponent<Monster>().scriptManager = gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

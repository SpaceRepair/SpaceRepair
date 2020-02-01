﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoles : MonoBehaviour
{
    private float nextActionTime = 0f; // Keisti jeigu skyle atsiranda su animacija.
    private GameObject[] holes;
    private List<GameObject> PlacedHoles;

    [SerializeField]
    private float period = 6.0f;

    [SerializeField]
    private Transform holePrefab;
    [SerializeField]
    private Transform holePrefab2;

    private Damage damageController;

    // Start is called before the first frame update
    void Start()
    {
        holes = GameObject.FindGameObjectsWithTag("Hole");
        PlacedHoles = new List<GameObject>();
        damageController = GameObject.Find("DamageBar").GetComponent<Damage>();

        /*if (holes.Length == 0)
        {
            Debug.Log("No objects found!");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        // Code inside if block runs in interval of 3 seconds.
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            SpawnAHole( holes[Random.Range(0, holes.Length)] );
        }
    }

    public void RemoveAHole()
    {
        // Removes a hole
    }

    private void SpawnAHole(GameObject hole)
    {
        //Debug.Log("Positions: " + hole.transform.position.x + " " + hole.transform.position.y);
        if (! HoleExists(hole))
        {
            Transform newHole;
            if (Random.Range(0, 2) == 0)
            {
                newHole = Instantiate(holePrefab);
            }
            else
            {
                newHole = Instantiate(holePrefab2);
            }

            newHole.transform.position = new Vector3(hole.transform.position.x, hole.transform.position.y, 0);
            PlacedHoles.Add(hole);
            damageController.MakeDamage(0.1f);

        }
    }

    private bool HoleExists(GameObject hole)
    {
        foreach (var item in PlacedHoles)
        {
            if (item.transform.position == hole.transform.position)
            {
                return true;
            }
        }

        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoles : MonoBehaviour
{
    private float nextActionTime = 0f; // Keisti jeigu skyle atsiranda su animacija.
    private GameObject[] holes;

    [SerializeField]
    private float period = 3.0f;

    [SerializeField]
    private Transform holePrefab;

    // Start is called before the first frame update
    void Start()
    {
        holes = GameObject.FindGameObjectsWithTag("Hole");

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

    private void SpawnAHole(GameObject hole)
    {
        Debug.Log("Positions: " + hole.transform.position.x + " " + hole.transform.position.y);

       //Instantiate(holePrefab, new Vector2(hole.transform.position.x, hole.transform.position.y));
    }
}

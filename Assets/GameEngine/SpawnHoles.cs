using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoles : MonoBehaviour
{
    private float nextActionTime = 0f; // Keisti jeigu skyle atsiranda su animacija.
    private GameObject[] holes;
    private List<GameObject> PlacedHoles;

    [SerializeField]
    private float period;

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
        SpawnAHole( holes[Random.Range(0, holes.Length)] );
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

    private void SpawnAHole(GameObject holePlace)
    {
        //Debug.Log("Positions: " + hole.transform.position.x + " " + hole.transform.position.y);
        if (! HoleExists(holePlace))
        {
            Transform newHole;
            int number = Random.Range(0, 2);
            if (number == 0)
            {
                newHole = Instantiate(holePrefab);
            }
            else
            {
                newHole = Instantiate(holePrefab2);
            }

            newHole.transform.position = new Vector3(holePlace.transform.position.x, holePlace.transform.position.y, 0);
            PlacedHoles.Add(holePlace);
            var player = GameObject.Find("Player").GetComponent<Player>();
            player.AddNewHole(newHole.gameObject);
            var damageAmount = newHole.GetComponent<Hole>().DamageAmount;
            damageController.DealDamage(damageAmount);

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

    public void FreeHole(GameObject hole)
    {
        PlacedHoles.Remove(hole);
    }
}

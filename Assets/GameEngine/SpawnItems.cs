using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    private float nextActionTime = 0f; // Keisti jeigu item atsiranda su animacija.
    private GameObject[] itemPlaces;

    private List<Transform> scraps;
    private List<GameObject> PlacedItems;

    [SerializeField]
    private float period = 3.0f;

    // Item prefabs
    [SerializeField] private Transform Scrap1;
    [SerializeField] private Transform Scrap2;
    [SerializeField] private Transform Scrap3;
    [SerializeField] private Transform Scrap4;
    [SerializeField] private Transform Scrap5;
    [SerializeField] private Transform Scrap6;
    [SerializeField] private Transform Scrap7;
    [SerializeField] private Transform Scrap8;



    // Start is called before the first frame update
    void Start()
    {
        scraps = new List<Transform>();
        scraps.Add(Scrap1);
        scraps.Add(Scrap2);
        scraps.Add(Scrap3);
        scraps.Add(Scrap4);
        scraps.Add(Scrap5);
        scraps.Add(Scrap6);
        scraps.Add(Scrap7);
        scraps.Add(Scrap8);

        itemPlaces = GameObject.FindGameObjectsWithTag("Item");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;

            SpawnAnItem( itemPlaces[Random.Range(0, itemPlaces.Length)] );
        }
    }

    private void SpawnAnItem(GameObject item)
    {
        Transform newItem = Instantiate(scraps[ Random.Range(0, scraps.Count + 1) ]);
        newItem.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 0);
    }
}

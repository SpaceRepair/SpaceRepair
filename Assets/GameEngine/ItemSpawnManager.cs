﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField]
    private float SpawnInterval = 3.0f;

    [SerializeField]
    public List<Scrap> scrapPrefabs;
    [SerializeField]
    public List<GameObject> positions;

    private Dictionary<Transform, Scrap> placedScraps = new Dictionary<Transform, Scrap>();
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (GameManager.GameRunning)
        {
            var position = positions[random.Next(0, positions.Count)].transform;
            while (placedScraps.ContainsKey(position))
            {
                position = positions[random.Next(0, positions.Count)].transform;
            }

            var scrap = Instantiate(scrapPrefabs[random.Next(0, scrapPrefabs.Count)]);
            scrap.transform.position = position.position;
            placedScraps.Add(position, scrap);
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
}

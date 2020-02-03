using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    [SerializeField]
    private float SpawnInterval = 3.0f;

    [SerializeField]
    public List<Scrap> scrapPrefabs;
    [SerializeField]
    public List<GameObject> positions;

    private static Dictionary<Transform, Scrap> placedScraps;
    private System.Random random = new System.Random();

    public int MaxPlacedScraps = 4;

    // Start is called before the first frame update
    void Start()
    {
        placedScraps = new Dictionary<Transform, Scrap>();
        SpawnItem();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (GameManager.GameRunning)
        {
            if (placedScraps.Keys.Count < positions.Count && placedScraps.Count <= MaxPlacedScraps)
            {
                SpawnItem();
            }

            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void SpawnItem()
    {
        var position = positions[random.Next(0, positions.Count)].transform;
        while (placedScraps.ContainsKey(position))
        {
            position = positions[random.Next(0, positions.Count)].transform;
        }

        var scrap = Instantiate(scrapPrefabs[random.Next(0, scrapPrefabs.Count)]);
        scrap.transform.position = position.position;
        placedScraps.Add(position, scrap);
    }

    public static void PickUpScrap(Scrap scrap)
    {
        placedScraps.Remove(placedScraps
            .First(k => k.Value == scrap)
            .Key);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rect areaSpawn;
    public float tMin, tMax;
    public Mosca mosca;

    private void Start()
    {
        StartCoroutine(SpawnMoscas());
    }

    public IEnumerator SpawnMoscas()
    {
        while (true)
        {
            Vector3 posicion = new Vector3(
                Random.Range(transform.position.x - areaSpawn.width / 2, transform.position.x + areaSpawn.width / 2),
                Random.Range(transform.position.y - areaSpawn.height / 2, transform.position.y + areaSpawn.height / 2),
                0);
            Instantiate(mosca, posicion, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(tMin, tMax));
        }
    }
}

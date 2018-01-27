using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector2 area;
    public float tMin, tMax;
    public GameObject[] spawns;

    private void Start()
    {
        StartCoroutine(SpawnMoscas());
    }

    public IEnumerator SpawnMoscas()
    {
        while (true)
        {
            Vector3 posicion = new Vector3(
                Random.Range(transform.position.x - area.x / 2, transform.position.x + area.x / 2),
                Random.Range(transform.position.y - area.y / 2, transform.position.y + area.y / 2),
                0);
            Instantiate(spawns[Random.Range(0, spawns.Length)], posicion, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(tMin, tMax));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(area.x, area.y, 1));
    }
}

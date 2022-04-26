using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateSpawnSystem : MonoBehaviour
{
    public Sprite presPlatDis;
    public Sprite presPlatAct;
    private SpriteRenderer current;

    // variabile contenente l'oggetto che voglio spawnare
    public GameObject newObjectToSpawn;

    // variabile contenente la posizione dello spawn
    public Transform newObjectToSpawnLocation;

    private GameObject spawnedEntity;

    private void Start()
    {
        current = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        current.sprite = presPlatAct;

        // spawno nella posizione data
        spawnedEntity = Instantiate(newObjectToSpawn, newObjectToSpawnLocation.position, newObjectToSpawnLocation.rotation);

        // implementazione dello spawn dell'oggetto che voglio
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        current.sprite = presPlatDis;

        Destroy(spawnedEntity, 0);

        // implementazione della distruzione dell'oggetto creato
    }

}

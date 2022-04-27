using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressurePlateSpawnSystem : MonoBehaviour
{
    public Sprite pressurePlateDeactivate;
    public Sprite pressurePlateActive;
    private SpriteRenderer current;
    private GameObject spawnedEntity;

    private void Start()
    {
        current = GetComponent<SpriteRenderer>();
    }

    // quando entro spawno la roba
    private void OnTriggerEnter2D(Collider2D collision)
    {
        current.sprite = pressurePlateActive;
        spawnedEntity = cloneObject();
    }


    // distruzione dell'oggetto spawnato quando si esce dalla collider
    private void OnTriggerExit2D(Collider2D other)
    {
        current.sprite = pressurePlateDeactivate;
        Destroy(spawnedEntity, 0);
    }

    // ---

    public GameObject newObjectToSpawn;
    public Transform newObjectToSpawnLocation;
    public string newObjectToSpawnLayerName;
    private SpriteRenderer newObjectToSpawnSprite;
    private GameObject cloneObject(){
        GameObject returnValue = Instantiate(newObjectToSpawn, newObjectToSpawnLocation.position, newObjectToSpawnLocation.rotation);
        newObjectToSpawnSprite = returnValue.GetComponent<SpriteRenderer>();
        newObjectToSpawnSprite.sortingOrder = 0;
        newObjectToSpawnSprite.sortingLayerName = newObjectToSpawnLayerName;

        return returnValue;
    }

}

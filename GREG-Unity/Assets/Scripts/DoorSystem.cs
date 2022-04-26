using UnityEngine;

public class DoorSystem : MonoBehaviour
{
    // creazione di variabili di tipo sprite
    public Sprite open;
    public Sprite close;
    private SpriteRenderer current;

    private void Start()
    {
        current = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        current.sprite = open;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        current.sprite = close;
    }
}

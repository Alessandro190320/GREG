using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    public float nextWaypointDistance= 0.01f;
    private Vector2 movement;
    Path path;
    private int currentWaypoint =0;
    private bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    public Sprite[] directionSprite;

    public const int UP = 0;
    public const int LEFT = 1;
    public const int RIGHT = 2;
    public const int DOWN = 3;

    void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void Update()
    {
        if (path == null){
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath=true;
            return;
        } else {
            reachedEndOfPath = false;
        }

        /**
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
    	Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        */

        Vector3 directionToGo =  target.position-path.vectorPath[currentWaypoint];
        float angle = Mathf.Atan2(directionToGo.y,directionToGo.x) *Mathf.Rad2Deg;

        spriteRenderer.sprite = directionSprite[DetectDirection(angle)];
        // rb.rotation=angle; // la fa girare in modo storto

        directionToGo.Normalize();
        movement = directionToGo;

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance< nextWaypointDistance){
            currentWaypoint++;
        }
    }

    void FixedUpdate() {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction*speed*Time.deltaTime) );
    }

    void OnPathComplete(Path p){
        if(!p.error){
            path=p;
            currentWaypoint =0;
        }
    }

    public int DetectDirection(float angle){
        if (angle > -60 && angle <= 60) return UP;
        else if (angle > 60 && angle <= 120) return LEFT;
        else if (angle > -120 && angle <= -60) return RIGHT;
        else return DOWN;
    }
}

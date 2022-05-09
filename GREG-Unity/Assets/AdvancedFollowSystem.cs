using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedFollowSystem : MonoBehaviour
{

    void Start () {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation=true;

    }
}

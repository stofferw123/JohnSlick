using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float MoveSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * MoveSpeed;
    }
}

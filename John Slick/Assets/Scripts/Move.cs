using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    float h, v;
    [SerializeField]
    float speed, recoil;
    Vector2 forwardDir;

    void Start()
    {
        forwardDir = -transform.right * recoil;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");


        if(h != 0 || v != 0)
        {
            forwardDir = (new Vector2(h, v).normalized * recoil) * -1;
        }

        if (Input.GetKeyDown(KeyCode.Space)) // simulating recoil when shooting
        {
            PushObject(forwardDir);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(h, v).normalized * speed);
    }

    public void PushObject(Vector2 dir)
    {
        rb.AddForce(dir);
    }
}

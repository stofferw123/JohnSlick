using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterInterval : MonoBehaviour
{
    [SerializeField]
    float interval;
    void Start()
    {
        if (IsInvoking())
        {
            CancelInvoke();
        }
        Invoke("Destroy", interval);
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}

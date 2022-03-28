using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterInterval : MonoBehaviour
{
    public float interval;

    void OnEnable()
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

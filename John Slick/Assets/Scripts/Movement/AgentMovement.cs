using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class AgentMovement : MonoBehaviour
{
    [SerializeField]
    public MovementDataSO MovementData;
    [SerializeField]
    protected float currentVelocity = 3;

    [SerializeField]
    Vector2 recoil = Vector2.zero;
    [field: SerializeField]
    public UnityEvent<float> OnVelocityChange { get; set; }

    [SerializeField]
    [Range(0.05f, 1)]
    float recoilDuration; 
    
    [SerializeField]
    [Range(0.05f, 3)]
    float recoilStrength;


    Rigidbody2D rb;

    protected Vector2 movementDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            if (Vector2.Dot(movementInput.normalized, movementDirection) < 0)
                currentVelocity = 0;
            movementDirection = movementInput.normalized;
        }
        currentVelocity = CalculateSpeed(movementInput);
    }

    private float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            currentVelocity += MovementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= MovementData.deacceleration * Time.deltaTime;
        }
        return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
    }

    public void DoRecoil(Vector2 recoilAmount) // easier to call from another script than a coroutine
    {
        StopAllCoroutines();
        StartCoroutine("Recoil", recoilAmount);
    }

    IEnumerator Recoil(Vector2 recoilAmount) // question is if this shouldn't sit somewhere else
    {
        recoil = recoilAmount * recoilStrength;
        yield return new WaitForSeconds(recoilDuration);
        recoil = Vector2.zero;
    }

    private void FixedUpdate() // can't easily add forces to this, how would you do recoil effect?
    {
        OnVelocityChange?.Invoke(currentVelocity);
        rb.velocity = currentVelocity * movementDirection.normalized + recoil;
    }
}

// so we want to move an enemy with a path finder



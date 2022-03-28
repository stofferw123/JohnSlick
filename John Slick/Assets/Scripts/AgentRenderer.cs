using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("Right cross product " + Vector3.Cross(Vector2.up, Vector2.right));
        //Debug.Log("leftoss product " + Vector3.Cross(Vector2.up, Vector2.right));
    }

    public void FaceDirection(Vector2 pointerinput)
    {
        var direction = (Vector3)pointerinput - transform.position;
        var result = Vector3.Cross(Vector2.up, direction);

        if (result.z > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (result.z < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void FaceDirectionEnemy(Vector2 movingDir)
    {
        if (movingDir.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (movingDir.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

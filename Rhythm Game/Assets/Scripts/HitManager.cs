using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    public bool triggerEntered;
    int layerMask;
    public KeyCode key;

    private void Start()
    {
        layerMask = LayerMask.GetMask("Hit");
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position + new Vector3(0f, 0f, -0.01f), Vector3.forward, 1.0f, layerMask);
            Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            if (hit.Length > 0)
            {
                Debug.Log(hit[0].collider.tag);
            }
            else if (hit.Length <= 0)
            {
                Debug.Log("Miss");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerEntered = false;
    }
}

public enum HitRating
{
    GOOD,
    GREAT,
    PERFECT
}

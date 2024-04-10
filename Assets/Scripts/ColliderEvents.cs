using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvents : MonoBehaviour
{

    public UnityEvent OnTriggerEnter, OnTriggerExit, OnCollisionEnter, OnCollisonExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerEnter?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnTriggerExit?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollisionEnter?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        OnCollisonExit?.Invoke();
    }
}

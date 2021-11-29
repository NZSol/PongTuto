using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager manager;

    [SerializeField]
    Rigidbody2D rb = null;

    public void SetDirection(Vector3 dir)
    {
        float speed = Random.Range(1,2);
        var direction = dir - transform.position / 3;
        rb.AddForce(direction * speed);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.name.Contains("Goal"))
        {
            manager.GetPos(transform.position);
            manager.timer = true;
            Destroy(gameObject);
        }
    }
}

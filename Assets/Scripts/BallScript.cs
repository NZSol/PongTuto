using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager manager;

    [SerializeField]
    Rigidbody2D rb = null;
    [SerializeField]
    float speed = 10;

    public void SetDirection(Vector3 dir)
    {
        //float speedVar = Random.Range(1,5);
        var direction = dir - transform.position;
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name.Contains("Goal"))
        {
            manager.GetPos(transform.position);
            manager.timer = true;
            Destroy(gameObject);
        }
    }
}

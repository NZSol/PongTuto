using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public enum player { P1, P2};
    public player myPlayer = player.P1;
    [SerializeField]
    float speed = 5;

    Rigidbody rb = null;
    public BallScript ball;
    float clampMin = -4.55f, clampMax = 4.55f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (myPlayer)
        {
            case player.P1:
                P1Input();
                break;
            case player.P2:
                P2Input();
                break;
        }
    }


    void P1Input()
    {
        float vertical = Input.GetAxis("Vertical");
        gameObject.transform.position += vertical * Vector3.up * Time.deltaTime * speed;
        float y = transform.position.y;
        gameObject.transform.position = new Vector3(transform.position.x, Mathf.Clamp(y, clampMin, clampMax), 0); ;

    }

    void P2Input()
    {
        float vertical = Input.GetAxis("Vertical2");
        gameObject.transform.position += vertical * Vector3.up * Time.deltaTime * speed;
        float y = transform.position.y;
        gameObject.transform.position = new Vector3(transform.position.x, Mathf.Clamp(y, clampMin, clampMax), 0);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        print("HIT");
        if (collision.gameObject.name.Contains("Ball"))
        {
            switch (myPlayer)
            {
                case player.P1:
                    ball.GetComponent<Rigidbody2D>().AddForce(0.5f * Vector3.right, ForceMode2D.Impulse);
                    break;
                case player.P2:
                    ball.GetComponent<Rigidbody2D>().AddForce(-0.5f * Vector3.right, ForceMode2D.Impulse);
                    break;
            }
        }
    }

}

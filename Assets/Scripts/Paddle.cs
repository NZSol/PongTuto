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
    }

    void P2Input()
    {
        float vertical = Input.GetAxis("Vertical2");
        print(vertical);
        gameObject.transform.position += vertical * Vector3.up * Time.deltaTime * speed;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Ball"))
        {
            switch (myPlayer)
            {
                case player.P1:
                    ball.GetComponent<Rigidbody>().AddForce(0.5f * Vector3.right, ForceMode.Impulse);
                    break;
                case player.P2:
                    ball.GetComponent<Rigidbody>().AddForce(-0.5f * Vector3.right, ForceMode.Impulse);
                    break;
            }
        }
    }

}

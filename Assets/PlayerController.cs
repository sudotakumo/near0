using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // ˆÚ“®‘¬“x
    private Rigidbody2D rb;
    private Vector3 mid = new Vector3(0,-2,0);
    private Vector3 left = new Vector3(-5, -2, 0);
    private Vector3 right = new Vector3(5, -2, 0);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = left;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToRight();
        }
        /*else if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.W))
        {
            MoveToMid();
        }*/

    }

    private void MoveToLeft()
    {
        rb.MovePosition(left);
    }

    private void MoveToRight()
    {
        rb.MovePosition(right);
    }
    private void MoveToMid()
    {
        rb.MovePosition(mid);
    }
}

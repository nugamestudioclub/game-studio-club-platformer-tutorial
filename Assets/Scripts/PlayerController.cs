
using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 25;
    [SerializeField]
    private float jumpPower = 10;
    private Rigidbody2D body;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }
        if (Input.GetKey(KeyCode.D)) {
            body.AddForce(moveSpeed * Time.deltaTime * Vector2.right, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A)) {
            body.AddForce(moveSpeed * Time.deltaTime * Vector2.left, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        float yMovement = body.velocity.y;
        if (Mathf.Abs(yMovement) < Mathf.Epsilon) {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        float yMovement = body.velocity.y;
        if (Mathf.Abs(yMovement) >  Mathf.Epsilon) {
            isGrounded = false;
        }
    }

    private void Jump() {
        Vector2 oldVelocity = body.velocity;
        Vector2 newVelocity = new Vector2(oldVelocity.x, jumpPower);
        body.velocity = newVelocity;
    }
}

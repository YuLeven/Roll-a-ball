using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private struct Direction
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";
    }

    private Rigidbody rigidBody;

    public float speed;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(Direction.HORIZONTAL);
        float moveVertical = Input.GetAxis(Direction.VERTICAL);

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.AddForce(movement * speed);
    }
}

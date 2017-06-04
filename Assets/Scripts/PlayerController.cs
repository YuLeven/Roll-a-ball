using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private const string PICK_UP = "PickUp";

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PICK_UP))
        {
            other.gameObject.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private const string PICK_UP = "PickUp";
    private const int TOTAL_GAME_OBJECTS = 14;

    private Rigidbody rigidBody;
    private int count;

    public float speed;
    public Text countText;
    public Text winText;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        UpdateCounterText();
        winText.text = "";
    }

    private void UpdateCounterText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= TOTAL_GAME_OBJECTS)
        {
            winText.text = "You win!";
        }
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
            count++;
            UpdateCounterText();
        }
    }
}

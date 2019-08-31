using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    public bool didItHit;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 26)
        {
            winText.text = "You Win!";
        }
    }
    void Update()
    {
        didItHit = Physics.Raycast(transform.position, -Vector3.up, 0.51f);
        
        if (rb.position.y <= .6 && rb.position.y >=.45)
            if (didItHit && Input.GetKeyDown("space"))
        {
            if (Input.GetKeyDown("space"))
            {
                //transform.Translate(Vector3.up * 150 * Time.deltaTime, Space.World);
                rb.AddForce(0, 10, 0, ForceMode.Impulse);
            }
        }
    }

}
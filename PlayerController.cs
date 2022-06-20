using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 20.0f;
    private int score = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score" + score;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        // set starting point of the Vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        // add game speed 10 is slow,  15+ is faster
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        other.gameObject.SetActive(false);
        score = score + 10;
        UpdateScore();
    }

}

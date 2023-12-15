using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 PlayerDirection;
    bool speedup;
    bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        PlayerDirection = new Vector2(directionX, directionY).normalized;
        speedup = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
    }

    void FixedUpdate()
    {
        float moveAmount = playerspeed;
        if (speedup)
        {
            moveAmount = moveAmount * 2;
        }
        rb.velocity = new Vector2(PlayerDirection.x * moveAmount, PlayerDirection.y * moveAmount);

    }
}
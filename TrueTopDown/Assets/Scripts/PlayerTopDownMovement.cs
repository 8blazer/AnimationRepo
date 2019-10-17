using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;
        transform.up = mousePosition - transform.position;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = x * transform.right + y * transform.up;
        moveDir.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
    }
}

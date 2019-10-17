using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 2.0f;
    public float paceSpeed = 1.5f;
    public float chaseTriggerDistance = 5.0f;
    Vector3 startPosition;
    bool home = true;
    public Vector3 paceDirection;
    public float paceDistance = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        if(chaseDirection.magnitude <= chaseTriggerDistance)
        {
            ChasePlayer();
        }else if (!home)
        {
            GoHome();
        }
        else
        {
            Pace();
        }
    }
    void ChasePlayer()
    {
        home = false;
        Vector2 chaseDirection = new Vector2(player.position.x - transform.position.x,
            player.position.y - transform.position.y);
        chaseDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = chaseDirection * chaseSpeed;
        transform.up = player.transform.position - transform.position;
    }
    void GoHome()
    {
        Vector3 homeDirection = new Vector3(startPosition.x - transform.position.x,
            startPosition.y - transform.position.y, transform.position.z);
        transform.up = homeDirection;
        if(homeDirection.magnitude < 0.2f)
        {
            transform.position = startPosition;
            home = true;
        }
        else
        {
            homeDirection.Normalize();
            GetComponent<Rigidbody2D>().velocity = homeDirection * paceSpeed;
        }
    }
    void Pace()
    {
        Vector3 displacement = transform.position - startPosition;
        transform.up = paceDirection;
        if(displacement.magnitude >= paceDistance)
        {
            paceDirection = -displacement;
        }
        paceDirection.Normalize();
        GetComponent<Rigidbody2D>().velocity = paceDirection * paceSpeed;
    }
}
/*
 *         Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = transform.position.z;
        transform.up = mousePosition - transform.position;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = x * transform.right + y * transform.up;
        moveDir.Normalize();
        GetComponent<Rigidbody2D>().velocity = moveDir * moveSpeed;
*/
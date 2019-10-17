using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
	}
    
}

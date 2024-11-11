using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(Tags.ENEMY_TAG)) {
            Destroy(other.gameObject);
        }
    }
}

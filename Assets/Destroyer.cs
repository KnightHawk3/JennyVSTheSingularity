using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag.Contains("Robot")) {
            Destroy(col.gameObject);
        }
    }
}

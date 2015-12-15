using UnityEngine;
using System.Collections;

public class PizzaScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("ayy lmao");
        if (collision.gameObject.tag == "Player") {
            CharacterManager.score++;
            Destroy(this.gameObject);
        }
    }
}

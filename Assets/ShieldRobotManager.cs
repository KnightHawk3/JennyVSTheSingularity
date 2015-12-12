using UnityEngine;
using System.Collections;

public class ShieldRobotManager : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5;
    public float jumpHeight = 300;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Renderer>().isVisible) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
	}
}

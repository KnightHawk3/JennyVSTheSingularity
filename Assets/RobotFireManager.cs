using UnityEngine;
using System.Collections;

public class RobotFireManager : MonoBehaviour {

    private bool invoked = false;
    public float firstdelay = 2500f;
    public float firerate = 2500f;
    public float speed = 10;
    public Rigidbody2D projectile;

    void LaunchProjectile() {
        Rigidbody2D projectileInst = (Rigidbody2D) Instantiate(projectile, transform.position - new Vector3(-1,0,0), transform.rotation);
        projectile.velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.GetComponent<Renderer>().isVisible && !invoked) {
            invoked = !invoked;
            InvokeRepeating("LaunchProjectile", firstdelay, firerate);
        }

	}
}

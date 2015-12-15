using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RotateScript : MonoBehaviour
{
    public float speed = 10f;
    public Vector3[] axis = {Vector3.up, Vector3.forward, Vector3.right};
    private int axis_current = 0;
    
    
    void Update ()
    {
        if (axis_current <= 2) {
            transform.Rotate(axis[axis_current], speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump")) {
            SceneManager.LoadScene("Main");
        } else if (Input.GetButtonDown("Right")) {
            if (axis_current < 3) {
                axis_current += 1;
            } else {
                axis_current = 0;
            }
        }
    }
}
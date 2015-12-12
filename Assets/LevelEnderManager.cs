using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnderManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        SceneManager.LoadScene("WinGame");
    }
}

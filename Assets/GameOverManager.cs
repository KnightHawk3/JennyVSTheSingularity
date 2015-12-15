using UnityEngine.UI;  //its a must to access new UI in script
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    public Text Score_UIText; // assign it from inspector
    void Start() {
        Score_UIText.text = "Game over\nScore: " + CharacterManager.score + "\nContinue?";
    }
}


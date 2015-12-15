using UnityEngine.UI;  //its a must to access new UI in script
using UnityEngine;

public class WinGameManager : MonoBehaviour {
    public Text Score_UIText; // assign it from inspector
    void Start() {
        Score_UIText.text = "You win!\nScore: " + CharacterManager.score + "\nContinue?";
    }
}
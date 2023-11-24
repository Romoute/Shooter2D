
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public GameObject triangleObject;
    private Triangle triangleScore;
    private void Start() {
        triangleScore = triangleObject.GetComponent<Triangle>();
    }
    void Update() {
        if (triangleScore != null) {

            scoreText.text = "Score: " + triangleScore.getScore().ToString();

        } else {
            Debug.LogError("TriangleScoreManager script not found on the specified object.");
        }
    }
}

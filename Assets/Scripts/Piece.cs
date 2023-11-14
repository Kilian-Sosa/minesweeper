using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour {
    public int xCoord, yCoord;
    public bool hasBomb;

    public void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (hasBomb) GetComponent<SpriteRenderer>().material.color = Color.red;
        else {
            // Get the Text component by navigating the hierarchy
            TextMeshProUGUI textComponent = GetComponentInChildren<TextMeshProUGUI>();

            if (textComponent != null) {
                // The Text component exists, update the text
                textComponent.text = Generator.generator.GetNumBombsAround(xCoord, yCoord).ToString();
            } else {
                Debug.LogError("Text component not found in the hierarchy of Piece.");
            }
        }
    }
}

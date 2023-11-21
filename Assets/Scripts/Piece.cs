using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour {
    public int xCoord, yCoord;
    public bool hasBomb;

    private void OnMouseDown() {
        if (hasBomb) GetComponent<SpriteRenderer>().material.color = Color.red;
        else {
            TextMeshProUGUI textComponent = GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null) 
                textComponent.text = Generator.generator.GetNumBombsAround(xCoord, yCoord).ToString();
            else Debug.LogError("Text component not found in the hierarchy of Piece.");
        }
    }
}

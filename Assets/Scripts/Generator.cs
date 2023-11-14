using UnityEngine;

public class Generator : MonoBehaviour {
    public GameObject[][] map;
    public GameObject piece;
    public int width, height, bombsNumber;

    private void Start() {
        map = new GameObject[width][];
        for (int i = 0; i < width; i++)
            map[i] = new GameObject[height];

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
        Camera.main.transform.position = 
            new Vector3(((float) width / 2) - 0.5f, ((float) height / 2) - 0.5f, -10);
        for (int i = 0; i < bombsNumber; i++)
            map[Random.Range(0, width)][Random.Range(0, height)].
                GetComponent<SpriteRenderer>().material.color = Color.red;
    }
}
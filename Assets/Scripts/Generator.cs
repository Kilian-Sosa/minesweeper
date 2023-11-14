using UnityEngine;

public class Generator : MonoBehaviour {
    public static Generator generator;
    public GameObject[][] map;
    public GameObject piece;
    public int width, height, bombsNumber;

    private void Start() {
        generator = this;
        InitializeMap();
        
        Camera.main.transform.position = 
            new Vector3(((float) width / 2) - 0.5f, ((float) height / 2) - 0.5f, -10);
    }

    private void InitializeMap() {
        map = new GameObject[width][];
        for (int i = 0; i < width; i++)
            map[i] = new GameObject[height];
        FillMap();
    }

    private void FillMap() {
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++) {
                map[i][j] = Instantiate(piece, new Vector2(i, j), Quaternion.identity);
                map[i][j].GetComponent<Piece>().xCoord = i;
                map[i][j].GetComponent<Piece>().yCoord = j;
            }
        SetBombs();
    }

    private void SetBombs() {
        for (int i = 0; i < bombsNumber; i++) {
            int x = Random.Range(0, width), y = Random.Range(0, height);
            if (!map[x][y].GetComponent<Piece>().hasBomb) map[x][y].GetComponent<Piece>().hasBomb = true;
            else i--;
        }
    }

    public int GetNumBombsAround(int x, int y) {
        int bombCount = 0;
        if (IsValidIndex(x - 1, y + 1) && map[x - 1][y + 1].GetComponent<Piece>().hasBomb) bombCount++; // Top-left
        if (IsValidIndex(x, y + 1) && map[x][y + 1].GetComponent<Piece>().hasBomb) bombCount++;     // Top
        if (IsValidIndex(x + 1, y + 1) && map[x + 1][y + 1].GetComponent<Piece>().hasBomb) bombCount++; // Top-right
        if (IsValidIndex(x - 1, y) && map[x - 1][y].GetComponent<Piece>().hasBomb) bombCount++;     // Left
        if (IsValidIndex(x + 1, y) && map[x + 1][y].GetComponent<Piece>().hasBomb) bombCount++;     // Right
        if (IsValidIndex(x - 1, y - 1) && map[x - 1][y - 1].GetComponent<Piece>().hasBomb) bombCount++; // Bottom-left
        if (IsValidIndex(x, y - 1) && map[x][y - 1].GetComponent<Piece>().hasBomb) bombCount++;     // Bottom
        if (IsValidIndex(x + 1, y - 1) && map[x + 1][y - 1].GetComponent<Piece>().hasBomb) bombCount++; // Bottom-right
        return bombCount;
    }

    private bool IsValidIndex(int x, int y) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
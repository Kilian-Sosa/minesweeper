using UnityEngine;

public class MazeGenerator : MonoBehaviour {
    public int width = 10;
    public int height = 10;
    public GameObject wallPrefab, pathPrefab;
    private int[,] maze;

    private void Start() {
        GenerateMaze();

        Camera.main.transform.position =
            new Vector3(((float)width / 2) - 0.5f, ((float)height / 2) - 0.5f, -10);
    }

    private void GenerateMaze() {
        maze = new int[width, height];

        for (int i = 0; i < width; i++) 
            for (int j = 0; j < height; j++) 
                maze[i, j] = 1; // 1 Represents wall, 0 represents path

        GeneratePath(1, 1);

        ShowMaze();
    }

    private void GeneratePath(int x, int y) {
        maze[x, y] = 0; // Mark the actual pos as part of the path

        int[] directions = { 0, 1, 2, 3 }; // Possible directions
        Shuffle(directions);

        for (int i = 0; i < directions.Length; i++) {
            int nextX = x + 2 * (directions[i] == 1 ? 1 : (directions[i] == 3 ? -1 : 0));
            int nextY = y + 2 * (directions[i] == 2 ? 1 : (directions[i] == 0 ? -1 : 0));

            if (IsValidPosition(nextX, nextY)) {
                maze[x + (nextX - x) / 2, y + (nextY - y) / 2] = 0; // Break the wall between the positions
                GeneratePath(nextX, nextY);
            }
        }
    }

    private void Shuffle(int[] array) {
        for (int i = array.Length - 1; i > 0; i--) {
            int j = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    private bool IsValidPosition(int x, int y) {
        return x > 0 && x < width - 1 && y > 0 && y < height - 1 && maze[x, y] == 1;
    }

    private void ShowMaze() {
        for (int j = height - 1; j >= 0; j--) {
            for (int i = 0; i < width; i++) {
                Vector2 position = new Vector2(i * 1f, j * 1f);
                if (maze[i, j] == 1) Instantiate(wallPrefab, position, Quaternion.identity);
                else Instantiate(pathPrefab, position, Quaternion.identity);
            }
            Debug.Log("\n");
        }
    }
}


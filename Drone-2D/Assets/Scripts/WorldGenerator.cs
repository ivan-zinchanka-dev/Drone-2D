using UnityEngine;
using System.Collections;
using TMPro;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private ForegroundObject[] blocks;
    [SerializeField] private ForegroundObject[] birds;
    [SerializeField] private BackgroundObject background;

    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI gameState;
    [SerializeField] private Controller player;

    private float gameTime = 0.0f;
    private float distance = 0.0f;
    public static bool pause { get; private set; } = true;

    public static float x_pos { get; private set; }

    public void StartGame() {

        pause = false;
        gameState.text = "";
        player.StartGame();
    }

    public void GameOver() {

        StartCoroutine(Restart());
    }

    private IEnumerator Restart() {

        gameState.text = "Game over!";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Scene");
    }

    public static float GetGameX() {

        return x_pos;
    }

    private void CreateObjectsPool(ForegroundObject[] source, int size) {

        int index;

        for (int i = 0; i < size; i++)
        {
            index = Random.Range(0, source.Length);
            ForegroundObject current = Instantiate(source[index]);
            current.transform.position = new Vector3(-25.0f, 0.0f, 1.0f);
        }
    }

    private void CreateObjectsPool(ForegroundObject source, int size)
    {
        for (int i = 0; i < size; i++)
        {
            ForegroundObject current = Instantiate(source);
            current.transform.position = new Vector3(-25.0f, 0.0f, 1.0f);
        }
    }

    public void CreateObjectsPool(BackgroundObject source, Transform parent, int size)
    {
        for (int i = 0; i < size; i++)
        {
            BackgroundObject current = (BackgroundObject)Object.Instantiate(source);
            current.transform.position = new Vector3(-40.0f, 0.0f, 1.0f);
        }
    }

    void Start()
    {
        pause = true;
        x_pos = 0;
        CreateObjectsPool(blocks, 12);
        CreateObjectsPool(birds, 10);
        CreateObjectsPool(background, parent, 1);

        gameState.text = "Tap to start";
    }

    void Update()
    {
        x_pos = transform.position.x;

        if (pause || !player.alive) { return; }

        gameTime += Time.deltaTime;
        distance += 10.0f * Time.deltaTime;
        score.text = string.Format("Distance: {0:D} m", (int)distance);
      
    }
}

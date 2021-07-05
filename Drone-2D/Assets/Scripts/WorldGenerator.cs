using UnityEngine;
using System.Collections;
using TMPro;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private Transform _parent = null;
    [SerializeField] private ForegroundObject[] _blocks = null;
    [SerializeField] private ForegroundObject[] _birds = null;

    [SerializeField] private TextMeshProUGUI _score = null;
    [SerializeField] private TextMeshProUGUI _gameState = null;
    [SerializeField] private Controller _player = null;

    private float _distance = 0.0f;
    private const string _scoreFormat = "Distance: {0:D} m";
    private const string _startMessage = "Tap to start";

    public static bool Pause { get; private set; } = true;
    public static float XPos { get; private set; }

    public void StartGame() {

        Pause = false;
        _gameState.text = "";
        _player.StartGame();
    }

    public void GameOver() {

        StartCoroutine(Restart());
    }

    private IEnumerator Restart() {

        _gameState.text = "Game over!";
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Scene");
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

    void Start()
    {
        Pause = true;
        XPos = 0;
        CreateObjectsPool(_blocks, 12);
        CreateObjectsPool(_birds, 10);
        _gameState.text = _startMessage;
    }

    void Update()
    {
        XPos = transform.position.x;

        if (Pause || !_player.IsAlive) { return; }

        _distance += 10.0f * Time.deltaTime;
        _score.text = string.Format(_scoreFormat, (int)_distance);
      
    }
}

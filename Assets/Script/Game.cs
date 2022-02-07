using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public CollisionScript collisionScript;
    public GameObject Player;
    public TailMovement _player;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject StartCanvas;
    public GameObject PlayingCanvas;
    public enum State
    {
        StartMenu,
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }


    private void Start()
    {
        if (LevelIndex == 0) LoadLevel1();
        if (LevelIndex == 1) LoadLevel2();
        if (LevelIndex == 2) LoadLevel3();
    }

    private void Update()
    {
        if (CurrentState == State.Playing)
        {
            Time.timeScale = 1;
            PlayingCanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            PlayingCanvas.SetActive(false);
        }


        if (gameStarted == false)
        {
            CurrentState = State.StartMenu;
            _player.enabled = false;
            Time.timeScale = 0;
            StartCanvas.SetActive(true);
        }
        else CurrentState = State.Playing;
    }

    public void OnPlayerDeath()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        collisionScript.StopCoroutine(collisionScript.TailCoroutine);
        collisionScript.StopCoroutine(collisionScript.BlockCoroutine);
        ReloadLevel();
    }

    public void OnPlayerWon()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;

        if (LevelIndex == 1) LoadLevel2();

        if (LevelIndex == 2) LoadLevel3();

        if (LevelIndex == 3)
        {
            LevelIndex = 0;
            ReloadLevel();
        }
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public bool gameStarted
    {
        get => PlayerPrefs.GetInt(GameStarted) == 1;
        set
        {
            PlayerPrefs.SetInt(GameStarted, gameStarted ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";
    public const string GameStarted = "gameStarted";

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CurrentState = State.Loss;
    }

    private void LoadLevel1()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 200;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 4; i++) _player.RemoveTail();
    }

    private void LoadLevel2()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 300;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 1; i++) _player.RemoveTail();
    }

    private void LoadLevel3()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 400;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 1; i++) _player.RemoveTail();
    }
}

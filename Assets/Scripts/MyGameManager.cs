using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{

    public event EventHandler OnPointsUpdate;
    public event EventHandler OnStateChanged;

    [SerializeField] private Player player;
    [SerializeField] private Color[] gameColors;

    [SerializeField] private GameObject[] levelPrefabs;
    private int levelRangeLow;
    private int levelRangeHigh;
    public static MyGameManager Instance { get; private set; }

    private enum State
    {
        Waiting,
        Paused,
        Playing,
        Finished
    };

    private State state;
    private int points;

    private void Awake()
    {
        state = State.Waiting;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
        Instance = this;
        points = 0;
        player.OnPointsItemInteract += Player_OnPointsItemInteract;
    }

    private void Start()
    {
        GameInput.Instance.OnPause += Input_OnPause;
        Player.Instance.OnGameOver += Player_OnGameOver;
        Player.Instance.OnPlayerFirstMove += Player_OnPlayerFirstMove;
    }

    private void Player_OnPlayerFirstMove(object sender, EventArgs e)
    {
        if (state == State.Waiting)
        {
            state = State.Playing;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.Playing:
                {
                    Time.timeScale = 1f;
                    break;
                }
            case State.Waiting:
            case State.Paused:
            case State.Finished:
                {
                    Time.timeScale = 0f;
                    break;
                }
            default: break;
        }
    }

    private void Player_OnGameOver(object sender, EventArgs e)
    {
        state = State.Finished;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Input_OnPause(object sender, EventArgs e)
    {
        if (state == State.Playing || state == State.Paused)
            TogglePause();
    }

    public void TogglePause()
    {
        if (state == State.Playing)
        {
            state = State.Paused;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
        else if (state == State.Paused)
        {
            state = State.Playing;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Player_OnPointsItemInteract(object sender, System.EventArgs e)
    {
        points++;
        OnPointsUpdate?.Invoke(this, EventArgs.Empty);
    }

    public Color GetColor(int index)
    {
        if (index >= 0 && index < gameColors.Length)
        {
            return gameColors[index];
        }

        return Color.black;
    }
    public Color GenerateRandomColor()
    {
        return gameColors[new System.Random().Next(0, gameColors.Length)];
    }
    public Color GenerateRandomColor(List<Color> colors)
    {
        while (true)
        {
            bool exists = false;
            Color randomColor = gameColors[new System.Random().Next(0, gameColors.Length)]; // Random index in array

            foreach (Color color in colors)
            {
                if (randomColor == color)
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                continue;
            }

            return randomColor;
        }
    }

    public void SpawnLevel(Vector3 location)
    {
        if (points <= 5)
        {
            levelRangeLow = 0; levelRangeHigh = 5;
        }
        else if (points > 5 && points <= 10)
        {
            levelRangeLow = 2; levelRangeHigh = 9;
        }
        else if (points > 10 && points <= 20)
        {
            levelRangeLow = 4; levelRangeHigh = 13;
        }
        else if (points > 20)
        {
            levelRangeLow = 6; levelRangeHigh = 13;
        }

        int rand = new System.Random().Next(levelRangeLow, levelRangeHigh);

        Instantiate(levelPrefabs[rand], location, Quaternion.identity);
    }

    public int GetPoints()
    {
        return points;
    }

    public bool IsPaused()
    {
        return state == State.Paused;
    }

    public bool IsWaiting()
    {
        return state == State.Waiting;
    }

    public bool IsPlaying()
    {
        return state == State.Playing;
    }

    public bool IsGameFinished()
    {
        return state == State.Finished;
    }
}

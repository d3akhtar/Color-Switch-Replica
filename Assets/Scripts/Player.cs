using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    [SerializeField] private GameInput gameInput;
    [SerializeField] private PlayerVisual playerVisual;

    public event EventHandler OnPointsItemInteract;
    public event EventHandler OnPlayerFirstMove;
    public event EventHandler OnGameOver;
    public event EventHandler OnPlayerJump;
    public event EventHandler OnPlayerColorSwitch;

    private Rigidbody2D rigidbody2D;

    private float jumpForce = 250f;
    public static Player Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerVisual.SetPlayerColor(MyGameManager.Instance.GenerateRandomColor());
        gameInput.OnJump += Player_OnJump;
    }

    private void Player_OnJump(object sender, System.EventArgs e)
    {
        if (MyGameManager.Instance.IsPlaying())
        {
            MovePlayer();
        }
        else
        {
            if (MyGameManager.Instance.IsWaiting())
            {
                OnPlayerFirstMove?.Invoke(this, EventArgs.Empty);
                MovePlayer();
            }
        }
    }

    private void MovePlayer()
    {
        OnPlayerJump?.Invoke(this, EventArgs.Empty);
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out ColorChangeItem colorChangeItem))
        {
            Color color = colorChangeItem.GetColor();
            playerVisual.SetPlayerColor(color);
            colorChangeItem.DestroySelf();
            OnPlayerColorSwitch?.Invoke(this, EventArgs.Empty);
        }
        else if (collision.transform.TryGetComponent(out PointsItem pointsItem))
        {
            OnPointsItemInteract?.Invoke(this, EventArgs.Empty);
            pointsItem.DestroySelf();
        }
        else if (collision.transform.TryGetComponent(out ObstacleComponent obstacleComponent))
        {
            if (obstacleComponent.IsObstacleSameColor(playerVisual.GetPlayerColor()))
            {
                // Player is alive
            }
            else
            {
                // Game would end
                OnGameOver?.Invoke(this, EventArgs.Empty);
                playerVisual.SetPlayerColor(new Color(0, 0, 0, 0));
            }
        }
        else if (collision.transform.TryGetComponent(out OutOfBoundsTrigger outOfBoundsTrigger))
        {
            // Game ends since player is falls off screen
            //OnGameOver?.Invoke(this, EventArgs.Empty);
            playerVisual.SetPlayerColor(new Color(0, 0, 0, 0));
        }
    }

    public Color GetColor()
    {
        return playerVisual.GetPlayerColor();
    }

}
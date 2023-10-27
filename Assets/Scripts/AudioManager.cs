using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioclipsSO audioRefs;
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this; 
    }

    private void Start()
    {
        Player.Instance.OnPlayerJump += Player_OnPlayerJump;
        Player.Instance.OnGameOver += Player_OnGameOver;
        Player.Instance.OnPlayerColorSwitch += Player_OnPlayerColorSwitch;
        MyGameManager.Instance.OnPointsUpdate += Game_OnPointsUpdate;
    }

    private void Player_OnPlayerColorSwitch(object sender, System.EventArgs e)
    {
        PlayColorSwitchSound();
    }

    private void Game_OnPointsUpdate(object sender, System.EventArgs e)
    {
        PlayPointSound();
    }

    private void Player_OnGameOver(object sender, System.EventArgs e)
    {
        PlayDeathSound();
    }

    private void Player_OnPlayerJump(object sender, System.EventArgs e)
    {
        PlayJumpSound();
    }

    private void PlayJumpSound()
    {
        PlaySound(audioRefs.jump);
    }

    private void PlayDeathSound()
    {
        PlaySound(audioRefs.dead);
    }

    private void PlayPointSound()
    {
        PlaySound(audioRefs.point);
    }

    private void PlayColorSwitchSound()
    {
        PlaySound(audioRefs.color);
    }

    private void PlaySound(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 0.2f);
    }
}

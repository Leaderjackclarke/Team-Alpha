using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManger 
{
    public enum sound
    {
        PlayerMove,
        PlayerJump,
        PressurePlate,

    }

    public static void PlaySound()
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GameAssets.i.playerJump);
    }
}

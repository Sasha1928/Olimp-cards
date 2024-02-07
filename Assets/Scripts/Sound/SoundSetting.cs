using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private GameManegerSO _gameManager;
    [SerializeField] private AudioSource[] _sound;
    [SerializeField] private AudioSource _muzikFight;

    private void Awake()
    {
        if (_muzikFight != null)
        {
            _muzikFight.volume = _gameManager.VolumeMusic;
        }
        if (_sound != null)
        {
            foreach (var sound in _sound)
            {
                sound.volume = _gameManager.VolumeSound;
            }
        }
    }
}

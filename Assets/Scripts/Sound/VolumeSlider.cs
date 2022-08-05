using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    void Start()
    {
        SoundManager.Instance.ChangeMusicVolume(_slider.value);
        SoundManager.Instance.ChangeEffectsVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
    }
}

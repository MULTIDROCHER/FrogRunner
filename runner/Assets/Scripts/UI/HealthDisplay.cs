using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Heart> _healthDisplay;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        for (int i = 0; i < _healthDisplay.Count; i++)
        {
            if (i < health)
            {
                _healthDisplay[i].FillHeart();
            }
            else
            {
                _healthDisplay[i].TakeHeart();
            }
        }
    }
}
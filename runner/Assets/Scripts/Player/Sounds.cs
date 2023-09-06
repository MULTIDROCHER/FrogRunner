using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip _eatFood;
    [SerializeField] private AudioClip _takeDamage;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent(out Enemy enemy))
            _source.PlayOneShot(_takeDamage);

        if (collider.TryGetComponent(out Food food))
            _source.PlayOneShot(_eatFood);
    }
}

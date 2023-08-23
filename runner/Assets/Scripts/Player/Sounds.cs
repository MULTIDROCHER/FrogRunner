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

    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Enemy>())
            _source.PlayOneShot(_takeDamage);

        if (collider.GetComponent<Food>())
            _source.PlayOneShot(_eatFood);
    }
}

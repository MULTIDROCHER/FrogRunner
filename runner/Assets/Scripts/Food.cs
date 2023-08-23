using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            player.RecoverHealth(_heal);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

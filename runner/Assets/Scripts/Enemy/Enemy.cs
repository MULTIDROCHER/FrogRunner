using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
            player.TakeDamage(_damage);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
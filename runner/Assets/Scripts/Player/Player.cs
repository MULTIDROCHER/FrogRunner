using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void RecoverHealth(int heal)
    {
        if (_health < _maxHealth)
            _health += heal;

        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
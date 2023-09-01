using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounce;

    private void Update()
    {
        transform.position += new Vector3(_speed * Time.deltaTime, 0);

        if (transform.position.x < _bounce)
            transform.position = new Vector3(-_bounce, transform.position.y);
    }
}
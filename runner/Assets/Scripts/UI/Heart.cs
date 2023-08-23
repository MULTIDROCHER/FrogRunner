using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private Sprite _emptyHeart;
    [SerializeField] private Sprite _fullHeart;

    private Image _heart;

    private void Awake()
    {
        _heart = GetComponent<Image>();
    }

    public void FillHeart()
    {
        _heart.sprite = _fullHeart;
    }

    public void TakeHeart()
    {
        _heart.sprite = _emptyHeart;
    }
}
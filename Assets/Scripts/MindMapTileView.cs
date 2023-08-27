using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindMapTileView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _flatSprite;
    [SerializeField] private Sprite _crossSprite;
    [SerializeField] private Sprite _questionSprite;
    [SerializeField] private Sprite _exclamationSprite;
    [SerializeField] private Color _foodColor;
    [SerializeField] private Color _exploredColor;
    private Color _unexploredColor = Color.black;
    private Color _hiddenColor = new Color(0.5f, 0.5f, 0.5f);

    public void ChangeType(Visibility visibility, Type type = Type.Ordinary, Status status = Status.Flat)
    {
        Color targetColor = _exploredColor;
        Sprite targetSprite = _flatSprite;

        if (type == Type.Food)
            targetColor = _foodColor;

        if (visibility == Visibility.Hidden)
            targetColor = Color.Lerp(targetColor, _hiddenColor, 0.5f);
        else if (visibility == Visibility.Unexplored)
            targetColor = _unexploredColor;

        if (status == Status.Cross)
            targetSprite = _crossSprite;
        else if (status == Status.Question)
            targetSprite = _questionSprite;
        else if (status == Status.Exclamation)
            targetSprite = _exclamationSprite;

        targetColor.a = 1f;
        _spriteRenderer.color = targetColor;
        _spriteRenderer.sprite = targetSprite;
    }

    public enum Type
    {
        Ordinary,
        Food
    }

    public enum Visibility
    {
        Unexplored,
        Explored,
        Hidden
    }

    public enum Status
    {
        Flat,
        Cross,
        Question,
        Exclamation
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }

    private void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}

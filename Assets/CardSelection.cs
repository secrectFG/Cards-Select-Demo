using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSelection : Singleton<CardSelection>
{
    public float moveDuration = 0.2f;
    public float moveDistance = 0.5f;
    public CardView Selected
    {
        get { return _Selected; }
        set
        {
            if (_Selected == value)
                return;
            if (_Selected != null)
            {
                _Selected.Selected = false;
                SelectAnimation(false);
            }
            _Selected = value;
            if (_Selected != null)
            {
                _Selected.Selected = true;
                SelectAnimation(true);
            }
        }
    }

    CardView _Selected;

    void SelectAnimation(bool selecting)
    {
        if(selecting)
            _Selected.transform.DOMoveY(_Selected.transform.position.y + moveDistance, moveDuration);
        else
            _Selected.transform.DOMoveY(_Selected.transform.position.y - moveDistance, moveDuration);
    }
}

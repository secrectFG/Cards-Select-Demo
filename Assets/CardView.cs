using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    public int cardId;

    public void OnClick()
    {
          //Debug.Log("Card " + cardId + " clicked!");
        var card = GameManager.Instance.GetCard(cardId);
        Debug.Log("µã»÷ÁË£º"+card.ToString());
    }
}

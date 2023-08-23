using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardView : MonoBehaviour
{
    public int cardId;

    [SerializeField]
    private GameObject selectedFrame;


    public bool Selected
    {
        get { return selectedFrame.activeSelf; }
        set { selectedFrame.SetActive(value); }
    }

    public void OnClick()
    {
          //Debug.Log("Card " + cardId + " clicked!");
        //var card = GameManager.Instance.GetCard(cardId);
        //Debug.Log("µã»÷ÁË£º"+card.ToString());
        GetComponentInParent<CardSelection>().Selected = this;
    }
}

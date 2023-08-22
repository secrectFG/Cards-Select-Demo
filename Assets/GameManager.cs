using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> 
{
    public Sprite[] cardSprites;
    public CardView cardPrefab;
    public Transform cardParent;
    public int cardCount = 10;
    public float cardWidth = 1f;

    public float dealDuration = 1f;
    public float delayBetweenCards = 0.2f;

    private Model.Poker poker = new();

    public Model.Card GetCard(int index)
    {
        return poker.GetCard(index+1);
    }

    public void DealCards()
    {
        //先清空所有子物体
        for (int i = 0; i < cardParent.childCount; i++)
        {
            Destroy(cardParent.GetChild(i).gameObject);
        }

        float totalWidth = cardCount * cardWidth;
        float startingX = cardParent.position.x - totalWidth / 2 + cardWidth / 2;

        List<int> cardIds = new List<int>();
        for (int i = 0; i < 52; i++)
        {
            cardIds.Add(i);
        }

        // Shuffle the cards
        for (int i = 0; i < cardIds.Count; i++)
        {
            int temp = cardIds[i];
            int randomIndex = Random.Range(i, cardIds.Count);
            cardIds[i] = cardIds[randomIndex];
            cardIds[randomIndex] = temp;
        }

        for (int i = 0; i < cardCount; i++)
        {
            CardView card = Instantiate(cardPrefab);

            // Position the card
            float cardX = startingX + i * cardWidth;
            card.transform.position = new Vector3(cardX, cardParent.position.y, cardParent.position.z);

            card.transform.SetParent(cardParent);
            card.transform.localScale = Vector3.one;
            //card.transform.localPosition = Vector3.zero;
            card.cardId = cardIds[cardIds.Count-1];
            cardIds.RemoveAt(cardIds.Count-1);

            

            DealCard(card.gameObject, i * delayBetweenCards);
        }
    }

    private void DealCard(GameObject card, float delay)
    {
        // Store the initial rotation
        Quaternion initialRotation = card.transform.rotation;

        // Create rotate animation
        var sequence = DOTween.Sequence();

        sequence.AppendInterval(delay);

        // Rotate card to half way over dealDuration / 2
        sequence.Append(card.transform.DORotate(new Vector3(0, 90, 0), dealDuration / 2));

        // Add a function callback here to do something when the card is half way turned
        // For example, change the card's sprite to show its face
        sequence.AppendCallback(() => HalfWayThere(card));

        // Rotate card to fully turned over dealDuration / 2
        sequence.Append(card.transform.DORotate(initialRotation.eulerAngles, dealDuration / 2));
    }

    private void HalfWayThere(GameObject card)
    {
        // Do something when the card is half way turned
        // For example, change the card's sprite to show its face
        
        var cardId = card.GetComponent<CardView>().cardId;
        //Debug.Log(card.name + " is half way there!" + cardId+" "+card+ " "+ cardSprites[cardId]);
        card.GetComponent<Image>().sprite = cardSprites[cardId];
    }
}

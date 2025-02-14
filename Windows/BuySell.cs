using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum State { NONE, BUY,SELL}
public class BuySell : MonoBehaviour
{
    public State state;
    public Button SellButton, CancelButton, BuyButton;
    public Slider citySlider, shipSlider;
    public TextMeshProUGUI shipText, cityText, amountText;
    int previousShipAmount=50, previousCityAmount=60;
    int amount = 0;
    void Start()
    {
        state = State.NONE;
        amount = 0;
        amountText.text = amount.ToString();
        shipText.text = previousShipAmount.ToString();
        cityText.text = previousCityAmount.ToString();
        shipSlider.maxValue = previousCityAmount;
        citySlider.maxValue = previousShipAmount;
    }
    public void BuyAmount()
    {
        state = State.BUY;
        amount = (int)shipSlider.value;
        amountText.text =  amount.ToString();
        shipText.text = (previousShipAmount+amount).ToString();
        cityText.text = (previousCityAmount - amount).ToString();
        citySlider.maxValue = previousShipAmount+amount;
       
    }
    public void SellAmount()
    {
        state = State.SELL;
        amount = (int)citySlider.value;
        amountText.text = amount.ToString();
        shipText.text = (previousShipAmount - amount).ToString();
        cityText.text = (previousCityAmount + amount).ToString();
        shipSlider.maxValue = previousCityAmount + amount;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (amount == 0)
            state = State.NONE;
        if (state==State.BUY)
        {
            BuyButton.gameObject.SetActive(true);
            SellButton.gameObject.SetActive(false);
            if (Input.GetKey(KeyCode.Escape))
                Reset();
        }
        else if (state==State.SELL)
        {
            BuyButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.Escape))
                Reset();
        }
       
        else if (state == State.NONE)
        {
            BuyButton.gameObject.SetActive(false);
            SellButton.gameObject.SetActive(false);
        }
       
        
    }


    public void Buy()
    {
        previousCityAmount -= (int)shipSlider.value;
        previousShipAmount += (int)shipSlider.value;
        shipText.text = (previousShipAmount).ToString();
        cityText.text = (previousCityAmount).ToString();
        amount = 0;
        amountText.text = amount.ToString();
        shipSlider.value = 0;
        shipSlider.maxValue = previousCityAmount;
    }
    public void Sell()
    {
        previousCityAmount += (int)citySlider.value;
        previousShipAmount -= (int)citySlider.value;
        shipText.text = (previousShipAmount).ToString();
        cityText.text = (previousCityAmount).ToString();
        amount = 0;
        amountText.text = amount.ToString();
        citySlider.value = 0;
        citySlider.maxValue = previousShipAmount;
        
    }
    public void Reset()
    {

        amount = 0;
        amountText.text = amount.ToString();
        citySlider.value = 0;
        shipSlider.value = 0;
    }
}

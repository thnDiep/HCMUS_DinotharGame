using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductInShopUI : MonoBehaviour
{
    public TextMeshProUGUI priceText;
    public GameObject buyButton;
    public int initPrice;
    public int currentPrice;
    public int increasePrice;
    public bool isMoney;

    private bool canBuy;
    private bool enoughMoney;
    private bool isNotOverBuyTime;
    private bool isInteractableBtn;

    void Start()
    {
        setPrice(initPrice);
        canBuy = false;
        enoughMoney = false;
        isNotOverBuyTime = true;
        isInteractableBtn = true;

        if (isMoney)
        {
            GameManager.MoneyChangedEvent += HandleMoneyChanged;
            HandleMoneyChanged(GameManager.Instance.getMoney());
        }
        else
        {
            GameManager.DiamondChangedEvent += HandleDiamondChanged;
            HandleDiamondChanged(GameManager.Instance.getDiamond());
        }
    }

    private void OnDestroy()
    {
        if (isMoney)
            GameManager.MoneyChangedEvent -= HandleMoneyChanged;
        else
            GameManager.DiamondChangedEvent -= HandleDiamondChanged;
    }

    private void HandleMoneyChanged(int newMoney)
    {
        if (newMoney >= currentPrice)
        {
            enoughMoney = true;
            updateButton();
        }
        else
        {
            enoughMoney = false;
            updateButton();
        }
    }

    private void HandleDiamondChanged(int newDiamond)
    {
        if(newDiamond >= currentPrice)
        {
            enoughMoney = true;
            updateButton();
        } else
        {
            enoughMoney = false;
            updateButton();
        }
    }

    public bool buyProduct()
    {
        bool isSuccess = GameManager.Instance.BuyProduct(isMoney, currentPrice);
        if(isSuccess)
        {
            setPrice(currentPrice + increasePrice);
            if (currentPrice >= initPrice * 5)
            {
                isNotOverBuyTime = false;
                updateButton();
            }

            return true;
        }

        return false;
    }

    public void setCanBuy(bool canBuy)
    {
        this.canBuy = canBuy;
        updateButton();
    }

    private void setPrice(int newPrice)
    {
        currentPrice = newPrice;
        priceText.text = currentPrice.ToString();
    }

    private void updateButton()
    {
        if (canBuy && enoughMoney && isNotOverBuyTime)
        {
            buyButton.GetComponent<Selectable>().interactable = true;
        } else
        {
            buyButton.GetComponent<Selectable>().interactable = false;
        }

        //Debug.Log("canBuy " + canBuy);
        //Debug.Log("enoughMoney " + enoughMoney);
        //Debug.Log("isNotOverBuyTime " + isNotOverBuyTime);
        //Debug.Log("isInteractableBtn " + isInteractableBtn);
    }
}

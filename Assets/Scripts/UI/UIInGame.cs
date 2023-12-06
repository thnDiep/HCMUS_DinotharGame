using UnityEngine;
using TMPro;


public class UIInGame : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI diamondText;
    public TextMeshProUGUI lifeText;
    public void setMoney(int amount)
    {
        if (moneyText != null)
        {
            moneyText.text = amount.ToString();
        }
    }
    public void setDiamond(int amount)
    {
        if (diamondText != null)
        {
            diamondText.text = amount.ToString();
        }
    }

    public void setLife(int amount)
    {
        if (diamondText != null)
        {
            lifeText.text = amount.ToString();
        }
    }

}

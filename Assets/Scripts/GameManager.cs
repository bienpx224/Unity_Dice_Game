using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public TextMeshProUGUI _totalMoneySmall;
    [SerializeField] public TextMeshProUGUI _totalMoneyBig;
    [SerializeField] public TextMeshProUGUI _counterText;
    [SerializeField] public Image _dice;
    private int counterLeft;
    private int small_money;
    private int big_money;
    private int round_id;
    private int result;
    private int diceNum = -1;
    private bool isPlaying = false;
    private const string DICE_PATH = "Texture/dice-";

    // Start is called before the first frame update
    void Start()
    {
        _totalMoneyBig.text = "0";
        _totalMoneySmall.text = "0";
        _counterText.text = "99";
        _dice.gameObject.SetActive(false);
    }
    public double GetRandomNumberInRange(int minNumber, int maxNumber)
    {
        return Random.Range(0, maxNumber) + minNumber;
    }
    public void OnNewData(JSONObject data)
    {
        isPlaying = true;
        // Debug.LogError(_data);
        // JSONObject data = new JSONObject(_data);
        Debug.LogError(data);

        small_money = (int)data["small_money"].n;
        big_money = (int)data["big_money"].n;

        counterLeft = 10 - (int)data["counter"].n;
        result = data["result"] == null ? -1 : (int)data["result"].n;
        diceNum = data["dice"] == null ? -1 : (int)data["dice"].n;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false) return;

        _totalMoneySmall.text = "" + small_money;
        _totalMoneyBig.text = "" + big_money;

        _counterText.text = "" + counterLeft;
        if (counterLeft <= 0)
        {
            _counterText.gameObject.SetActive(false);
            _dice.gameObject.SetActive(true);
            if (result == -1 || diceNum == -1)
            {
                int rd = (int)(GetRandomNumberInRange(1, 6));
                _dice.sprite = Resources.Load<Sprite>(string.Format("{0}{1}", DICE_PATH, rd));
            }
            else
            {
                Debug.LogError(string.Format("Result : {0} and Dice Number is {1}", result, diceNum));
                _dice.sprite = Resources.Load<Sprite>(string.Format("{0}{1}", DICE_PATH, diceNum));
            }

        }
        else
        {
            _dice.gameObject.SetActive(false);
            _counterText.gameObject.SetActive(true);
        }

    }

    public void OnPlayBtn()
    {

    }
}

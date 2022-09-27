using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _totalMoneySmall;
    [SerializeField] private TextMeshProUGUI _totalMoneyBig;
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Image _dice;

    // Start is called before the first frame update
    void Start()
    {
        _totalMoneyBig.text = "0";
        _totalMoneySmall.text = "0";
        _counterText.text = "99";
        _dice.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayBtn(){
        
    }
}

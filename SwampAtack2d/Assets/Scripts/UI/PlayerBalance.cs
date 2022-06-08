using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _balanceText;

    private void OnEnable()
    {
        _balanceText.text = _player.Money.ToString();
        _player.MoneyChanged += ChangeBalance;
    }

    private void OnDisable()
    {
        _player.MoneyChanged -= ChangeBalance;
    }

    private void ChangeBalance(int money)
    {
        _balanceText.text = money.ToString();
    }
}

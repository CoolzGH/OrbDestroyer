using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerScore : MonoBehaviour
{
    int _score;
    int _rowScore;
    int _rowScoreCounter;
    int _orbHits;
    string _previousOrb;
    [SerializeField] GameObject _text;

    private void OnEnable()
    {
        Orb.OnScoreIncreased += IncreasedScore;
    }

    private void OnDisable()
    {
        Orb.OnScoreIncreased -= IncreasedScore;
    }

    void IncreasedScore(string orbName)
    {
        _orbHits += 1;
        _score++;
        _text.GetComponent<TextMeshProUGUI>().text = "Score " + _score;
        if (_previousOrb == orbName || _orbHits == 1)
        {
            _rowScoreCounter++;
        }
        else
        {
            _rowScore = _rowScoreCounter * _rowScoreCounter - _rowScoreCounter;
            if (_rowScoreCounter > 1)
                _score--;
            _score += _rowScore;
            _text.GetComponent<TextMeshProUGUI>().text = "Score " + _score;
            _rowScore = 0;
            _rowScoreCounter = 1;
        }
        _previousOrb = orbName;
    }
}

using System;
using UnityEngine;

public class DataManager
{
    private float _score;
    private float _highScore;
    private DateTime _dateTimeAtTheBeginning;
    private TimeSpan _dateTimeEnd;
    private bool _newGame = true;

    public void SetUpScoreUpdater()
    {
        UIManagerScript.Instance.GameLost += GetHighScore;
        UIManagerScript.Instance.GameWon += UpdateScore;
        UIManagerScript.Instance.GameWon += WriteHighScore;
    }

    public void GetHighScore() 
    {
        _score = 0;
        _highScore = PlayerPrefs.GetFloat("HighScore");

        if (_highScore == 0)
        {
            _highScore = 99999;
        }

        if (_newGame==true)
        {
            SetDateTime();
            _newGame = false;
        }
        if(_newGame == false)
        {
            UpdateScore();
        }
    }

    private void SetDateTime()
    {
        _dateTimeAtTheBeginning = DateTime.Now;
    }

    public void UpdateScore()
    {
        _dateTimeEnd = DateTime.Now - _dateTimeAtTheBeginning;
        _score = (float)_dateTimeEnd.TotalSeconds + (float)_dateTimeEnd.TotalMinutes * 60;
        PlayerPrefs.SetFloat("Score", _score);

        if (_dateTimeEnd.TotalHours > 1)
        {
            _score = 99999;
        }
    }

    private void WriteHighScore()
    {
        if (_score < _highScore)
        {
            PlayerPrefs.SetFloat("HighScore", _score);
        }
    }
}
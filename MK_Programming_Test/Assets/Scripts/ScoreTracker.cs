using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    [SerializeField]
    int baseTimeScore;
    [SerializeField]
    int timeDeduction;

    int correctAnswers = 0;
    int timeScore = 0;

    int questionScore;
    float questionTimer;
    bool questionActive;

    public void ResetScore()
    {
        correctAnswers = 0;
        timeScore = 0;
    }

    public void QuestionAnswered(bool correct)
    {
        if (correct)
        {
            correctAnswers++;
            timeScore += questionScore;
        }
        questionActive = false;
    }

    public void NewQuestion()
    {
        questionScore = baseTimeScore;
        questionTimer = 0;
    }

    public void SetQuestionActive(bool value)
    {
        questionActive = value;
    }

    private void Update()
    {
        if (questionActive)
        {
            questionTimer += Time.deltaTime;
            if(questionTimer >= baseTimeScore / timeDeduction)
            {
                questionScore = 10;
            }
            else
            {
                questionScore = (int)(baseTimeScore - (timeDeduction * questionTimer));
            }
        }
    }

    public int GetAnswers()
    {
        return correctAnswers;
    }

    public int GetScore()
    {
        return timeScore;
    }
}

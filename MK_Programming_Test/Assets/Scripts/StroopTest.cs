using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StroopTest : MonoBehaviour
{
    public ScoreTracker score;
    public TMP_Text testWord;
    public Button[] options;
    public GameObject endScreen;

    [SerializeField]
    int questionCount;
    int questionNumber;
    ColourOptions correctColour;

    ColourOptions[] colourOptions =
    {
        new ColourOptions("Blue", Color.blue),
        new ColourOptions("Red", Color.red),
        new ColourOptions("Green", Color.green),
        new ColourOptions("Yellow", Color.yellow),
        new ColourOptions("Orange", new Color(1f,0.46f,0.07f)),
        new ColourOptions("Pink", new Color(1f,0.34f,0.64f)),
        new ColourOptions("Purple", new Color(0.6f,0f,0.6f)),
        new ColourOptions("Brown", new Color(0.38f,0.21f,0.1f))
    };

    struct ColourOptions
    {
        string p_name;
        Color p_colour;

        public ColourOptions(string name, Color colour)
        {
            p_name = name;
            p_colour = colour;
        }

        public string name
        {
            get { return p_name; }
        }

        public Color colour
        {
            get { return p_colour; }
        }
    };

    void Awake()
    {
        score = GetComponent<ScoreTracker>();
        testWord = GameObject.Find("Test_Word").GetComponent<TMP_Text>();
        options = GameObject.Find("Options").GetComponentsInChildren<Button>();
        endScreen.SetActive(false);
        GenerateNewTest();
    }

    public void GenerateNewTest()
    {
        questionNumber++;
        List<ColourOptions> questionColours = new List<ColourOptions>();
        for(int i = 0; i < options.Length; i++)
        {
            int colour = Random.Range(0, colourOptions.Length);
            while(questionColours.Contains(colourOptions[colour]))
            {
                colour = Random.Range(0, colourOptions.Length);
            }
            questionColours.Add(colourOptions[colour]);
        }
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponentInChildren<TMP_Text>().text = questionColours[i].name;
        }
        correctColour = questionColours[Random.Range(0, questionColours.Count)];
        testWord.color = correctColour.colour;
        int index = Random.Range(0, questionColours.Count);
        while(colourOptions[index].name == correctColour.name)
        {
            index = Random.Range(0, questionColours.Count);
        }
        testWord.text = questionColours[index].name;
        score.SetQuestionActive(true);
    }

    public void SelectAnswer(TMP_Text answer)
    {
        if(answer.text == correctColour.name)
        {
            score.QuestionAnswered(true);
        }
        else
        {
            score.QuestionAnswered(false);
        }
        if(questionNumber < questionCount)
        {
            GenerateNewTest();
        }
        else
        {
            endScreen.SetActive(true);
        }
    }
}

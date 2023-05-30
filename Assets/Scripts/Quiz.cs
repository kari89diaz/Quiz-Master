using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    int answerButtonsArray;
    void Start()
    {
        questionText.text = question.GetQuestion();
        for (answerButtonsArray = 0; answerButtonsArray < answerButtons.Length; answerButtonsArray++)
        {
            TextMeshProUGUI buttonText = answerButtons[answerButtonsArray].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnwser(answerButtonsArray);
        }
    }
    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnwser(correctAnswerIndex);
            questionText.text = "Incorrect, the correct answer was:\n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}

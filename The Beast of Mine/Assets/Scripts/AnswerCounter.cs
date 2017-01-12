using UnityEngine;
using System.Linq;

/**
 * Class to count the number of correct answers in an animator sequence 
 */
public class AnswerCounter : MonoBehaviour {

    // number of correct answers the user has
    private int correctAnswersNumber = 0;
    // the name of the condition that was correct in the previous state (if exists)
    private string previousCorrectAnswer;
    // model of answers based on the parameters of the animator which are also conditions to pass in the following state
    private string[] answerModel = { "Resposta1", "Resposta2", "Resposta3", "Resposta4" };

    /*
     *  Given a new correct answer id and the list of answer id, map it to the real parameter name of the animator
     */
    public void updatePreviousCorrectAnswer(string newCorrectAnswer, string[] RespostaID)
    {
        if (newCorrectAnswer != "" && RespostaID.Contains(newCorrectAnswer))
        {
            previousCorrectAnswer = answerModel[System.Array.IndexOf(RespostaID, newCorrectAnswer)];
        }
        
    }

    public void resetPreviousCorrectAnswer()
    {
        previousCorrectAnswer = "";
    }

    public string getPreviousCorrectAnswer()
    {
        return previousCorrectAnswer;
    }

    public void updateCorrectAnswersNumber(int update)
    {
        correctAnswersNumber += update;
    }

    public int getCorrectAnswersNumber()
    {
        return correctAnswersNumber;
    }

    public string[] getAnswerModel()
    {
        return answerModel;
    }
}

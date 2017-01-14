using UnityEngine;
using System.Linq;

/**
 * Class to count the number of correct answers in an animator sequence 
 */
public class AnswerCounter : MonoBehaviour {

    const string CORRECT_ANSWERS = "Correct_Answers";
    const string BAD_ANSWERS = "Bad_Answers";
    // the name of the condition that was correct in the previous state (if exists)
    private string previousCorrectAnswer = "";
    // model of answers based on the parameters of the animator which are also conditions to pass in the following state
    private string[] answerModel = { "Resposta1", "Resposta2", "Resposta3", "Resposta4" };
    private void Start()
    {
        if (!(PlayerPrefs.GetInt(SceneReloader.SCENE_RELOADED) == 1)) {
            PlayerPrefs.SetInt(CORRECT_ANSWERS, 0);
            PlayerPrefs.SetInt(BAD_ANSWERS, 0);
            PlayerPrefs.Save();
        }
    }
    
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
        PlayerPrefs.SetInt(CORRECT_ANSWERS, PlayerPrefs.GetInt(CORRECT_ANSWERS) + update);
    }

    public int getCorrectAnswersNumber()
    {
        return PlayerPrefs.GetInt(CORRECT_ANSWERS);
    }

    public void updateBadAnswersNumber(int update)
    {
        PlayerPrefs.SetInt(BAD_ANSWERS, PlayerPrefs.GetInt(BAD_ANSWERS) + update);
    }

    public int getBadAnswersNumber()
    {
        return PlayerPrefs.GetInt(BAD_ANSWERS);
    }

    public string[] getAnswerModel()
    {
        return answerModel;
    }
}

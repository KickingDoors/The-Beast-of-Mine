using UnityEngine;

/**
 * Class used in every steps of a sequence animator
 */
public class StateTracker : StateMachineBehaviour {

    private string[] answerModel;
    private AnswerCounter answerCounter;
    private Animator animator;

    /**
     * Function called when entering any state of a sequence
     */
    void OnStateEnter()
    {
        // retrieve animator and answer counter
        animator = GameObject.Find("GameManager").GetComponent<Animator>();
        answerCounter = GameObject.Find("GameManager").GetComponent<AnswerCounter>();
        // at each state, we try to update the answer counter
        updateAnswerCounter();
        // TODO : delete following lines as it is for test purpose
        Debug.Log("correct answers : "+answerCounter.getCorrectAnswersNumber());
        Debug.Log("bad answers : " + answerCounter.getBadAnswersNumber());
    }

    /**
     * Update the number of correct or bad answer based on the previous correct answer
     */
    private void updateAnswerCounter()
    {
        bool isAnswerCorrect = false;
        string previousCorrectAnswer = answerCounter.getPreviousCorrectAnswer();
        // if we had a previous correct answer, it means that in the previous state, the user had to click a button to choose an answer
        // we then have to check if the answer the user chose was the good one
        if (previousCorrectAnswer != "")
        {
            // we loop through the answer model (Resposta 1 to 4)
            foreach (string answer in answerCounter.getAnswerModel())
            {
                // if the animator triggered a change on an condition given in the answer model and that is the correct answer
                if (animator.GetBool(answer) && answerCounter.getPreviousCorrectAnswer() == answer)
                {
                    // then the user chose the good answer
                    isAnswerCorrect = true;
                    break;
                }
            }
            if (isAnswerCorrect)
            {
                answerCounter.updateCorrectAnswersNumber(1);
            } else
            {
                answerCounter.updateBadAnswersNumber(1);
            }
            // we reset the previous correct answer as we just consumed it
            answerCounter.resetPreviousCorrectAnswer();
        }
        
    }
}

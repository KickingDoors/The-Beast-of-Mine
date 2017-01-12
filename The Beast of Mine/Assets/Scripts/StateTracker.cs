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
        updateAnswerCouter();
        // TODO : delete following line as it is for test purpose
        Debug.Log("correct answers : "+answerCounter.getCorrectAnswersNumber());
    }

    /**
     * Increment the number of correct answer of 1 if the previous correct answer matches  
     */
    private void updateAnswerCouter()
    {
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
                    Debug.Log("answer " + answer + " is correct ! ");
                    // then the user chose the good answer
                    answerCounter.updateCorrectAnswersNumber(1);
                    break;
                }
            }
            // we reset the previous correct answer as we just consumed it
            answerCounter.resetPreviousCorrectAnswer();
        }
        
    }
}

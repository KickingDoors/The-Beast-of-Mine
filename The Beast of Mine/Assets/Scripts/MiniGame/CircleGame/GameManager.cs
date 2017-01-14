using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace CircleGame
{
    public class GameManager : MonoBehaviour
    {
        public Text countText;
        public Text endGameText;
        public float growSpeed = 0.06f;
        public float lifeTime = 0.4f;
        public int circleNumber = 10;
        private int createdCircles = 0;
        private int missedCircles = 0;
        public bool increaseSpeedGenerationOverTime = true;
        public float speedGenerationFactor = 0.006f;
        public bool variableCircleScale = true;
        public float minScale = 0.00000001f;
        public float maxScale = 0.5f;
        public float clickDelay = 0.8f;
        public float delayDisplayEndGameMessage = 4.0f;
        private string resourcePath = "prefabs/CircleGame/";
        private GameObject canvas;
        private void Start()
        {
            canvas = GameObject.Find("Canvas");
            // Create a canvas for the mini game to display score and end game message based on the existing canvas
            // we do this to have the same position and size, it makes it easier
            GameObject miniGameCanvas = Instantiate(canvas);
            // destroy every children as we don't need it here
            foreach (Transform child in miniGameCanvas.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            // create a score counter Text
            countText = Instantiate((Text)Resources.Load(resourcePath + "CountText", typeof(Text)));
            // create a end game Text
            endGameText = Instantiate((Text)Resources.Load(resourcePath + "EndGameMessage", typeof(Text)));
            Transform miniGameCanvasTransform = miniGameCanvas.transform;
            // add both Text elements to the mini game canvas object
            countText.transform.SetParent(miniGameCanvasTransform);
            endGameText.transform.SetParent(miniGameCanvasTransform);
            // add the mini game canvas to the mini game object
            miniGameCanvas.transform.SetParent(GameObject.Find("miniGame").transform);
            // reset Text objects pos to display them correctly in the canvas
            countText.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
            endGameText.rectTransform.anchoredPosition = new Vector3(0, 0, 0);
            Cursor.visible = true;
            canvas.SetActive(false);
        }

        public void endGame()
        {
            Debug.Log("End game");
            showEndGameMessage();
            StartCoroutine(wait()); 

        }

        private IEnumerator wait()
        {
            yield return new WaitForSeconds(delayDisplayEndGameMessage);
            canvas.SetActive(true);
            GameObject.Find("GameManager").GetComponent<Animator>().SetTrigger("PassMessage");
        }

        private void showEndGameMessage()
        {
            endGameText.text = "Game over, you missed " + missedCircles.ToString() + " out of " + circleNumber + " !";
        }

        public void updateCountText()
        {
            countText.text = "Missed : " + missedCircles.ToString();
        }

        public int getCreatedCircles()
        {
            return createdCircles;
        }

        public void increaseCreatedCircle()
        {
            createdCircles++;
        }

        public void increaseMissedCircle()
        {
            missedCircles++;
        }

        public float getMaxCircleSize()
        {
            return growSpeed * lifeTime * (1 / Time.fixedDeltaTime);
        }
    }

}

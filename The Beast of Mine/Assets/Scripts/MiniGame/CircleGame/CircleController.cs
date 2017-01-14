using UnityEngine;

namespace CircleGame
{
    public class CircleController : MonoBehaviour
    {
        public CircleGame.GameManager gameManager;
        private bool clicked = false;
        private GameObject parent;
        private Vector3 maxScale;
        void Start()
        {
            gameManager = GameObject.Find("miniGameManager").GetComponent<CircleGame.GameManager>();
            parent = gameObject.transform.parent.gameObject;
            Destroy(parent, gameManager.lifeTime + gameManager.clickDelay);
            var maxSize = gameManager.getMaxCircleSize();
            maxScale = new Vector3(transform.localScale.x + maxSize, transform.localScale.y + maxSize);
        }

        void FixedUpdate()
        {
            if (transform.localScale != maxScale)
            {
                changeLocalScale();
            }
        }

        void OnMouseDown()
        {
            if (transform.localScale == maxScale)
            {
                clicked = true;
                Destroy(parent);
            }
        }

        void OnDestroy()
        {
            if (!clicked)
            {
                gameManager.increaseMissedCircle();
                gameManager.updateCountText();
            }
        }

        void changeLocalScale()
        {
            transform.localScale = new Vector2(transform.localScale.x + gameManager.growSpeed, transform.localScale.y + gameManager.growSpeed);
        }
    }

}

using UnityEngine;
namespace CircleGame
{
    public class CircleGenerator : MonoBehaviour
    {
        public CircleGame.GameManager gameManager;
        public float minSpawnInterval = 0.5f;
        public float maxSpawnInterval = 0.8f;
        private float currentTime;
        private float nextSpawnTime;
        private float endTime = 0;
        private float totalLifeTime;
        public GameObject objectToGenerate;
        public void Start()
        {
            gameManager = GameObject.Find("miniGameManager").GetComponent<CircleGame.GameManager>();
            objectToGenerate = (GameObject)Resources.Load("prefabs/CircleGame/CircleGameObjectToGenerate", typeof(GameObject));
            generateNextSpawnTime();
            totalLifeTime = gameManager.lifeTime + gameManager.clickDelay;
        }

        public void FixedUpdate()
        {
            currentTime += Time.deltaTime;
            if (gameManager.getCreatedCircles() < gameManager.circleNumber && currentTime >= nextSpawnTime)
            {
                generateCircle();
                generateNextSpawnTime();
            }
            else if (gameManager.getCreatedCircles() == gameManager.circleNumber)
            {
                endTime += Time.deltaTime;
                if (endTime >= totalLifeTime)
                {
                    gameManager.endGame();
                    this.enabled = false; // to stop executing FixedUpdate 
                }
            }
        }

        public void generateCircle()
        {
            GameObject newObj = (GameObject)Instantiate(objectToGenerate, new Vector2(Random.Range(-10, 10), Random.Range(-4, 4)), Quaternion.identity);
            var innerCircle = newObj.transform.FindChild(GameObject.FindGameObjectWithTag("InnerCircle").transform.name).transform;
            innerCircle.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            if (gameManager.variableCircleScale)
            {
                var randomScale = Random.Range(gameManager.minScale, gameManager.maxScale);
                innerCircle.localScale = new Vector2(randomScale, randomScale);
            }
            var outerCircle = newObj.transform.FindChild(GameObject.FindGameObjectWithTag("OuterCircle").transform.name).transform;
            var maxSize = gameManager.getMaxCircleSize();
            outerCircle.transform.localScale = new Vector2(innerCircle.localScale.x + maxSize, innerCircle.localScale.y + maxSize);
            gameManager.increaseCreatedCircle();
            newObj.transform.SetParent(GameObject.Find("miniGameManager").transform);
        }


        private void generateNextSpawnTime()
        {
            if (gameManager.increaseSpeedGenerationOverTime)
            {
                minSpawnInterval -= gameManager.speedGenerationFactor;
                maxSpawnInterval -= gameManager.speedGenerationFactor;
            }
            currentTime = 0;
            nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;

    public float roadSpeed;

    public float minimumObjectDistance = 1;

    [Range(-1, -0.005f)]
    public float carTurningSpeed = -0.15f;

    public CarMovement car;
    public RoadBehavior roadBehavior;

    public GameObstacle gameObstaclePrefab;
    public GamePoint gamePointPrefab;

    public List<GameObject> activeObjects = new List<GameObject>();

    public ScoreScreen scoreScreen;

    public void StartGame()
    {
        //car.StartEngine();
        StartCoroutine(CarVoice());
        roadBehavior.roadSpeed = roadSpeed;
        car.roadXScale = roadBehavior.transform.localScale.z - 3.8f;
        car.turnSpeed = carTurningSpeed;
        StartCoroutine(SpawnObjectsRoutine());
    }

    public void StopGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        roadBehavior.roadSpeed = 0;

        StopAllCoroutines();
        FindObjectOfType<SoundManager>().Stop("CarVoice");
        //car.StopEngine();

        foreach (GameObject active in activeObjects)
        {
            Destroy(active);
        }

        scoreScreen.gameObject.SetActive(true);

        scoreScreen.UpdateScoreTXT(score);
    }

    public void SpawnObjects(GameObject pointPrefab, GameObject obstaclePrefab)
    {
        Vector3[] positions = new Vector3[2];

        positions = GetRandomPositions();

        if (positions[0].y > 0 && positions[1].y > 0)
        {
            pointPrefab.transform.position = positions[0];
            obstaclePrefab.transform.position = positions[1];

            GameObject point = Instantiate(pointPrefab);
            GameObject obstacle = Instantiate(obstaclePrefab);

            activeObjects.Add(point);
            activeObjects.Add(obstacle);
        }
    }

    public void AddPoint()
    {
        score += 1;

        FindObjectOfType<SoundManager>().Play("Coin");
    }


    public Vector3[] GetRandomPositions()
    {
        float randomX0 = Random.Range(-2.5f, 2.5f);
        float randomX1 = Random.Range(-2.5f, 2.5f);

        if (Mathf.Abs(randomX0 - randomX1) > minimumObjectDistance)
        {
            return new Vector3[] { new Vector3(randomX0, 0.5f, 100), new Vector3(randomX1, 0.1f, 100) };
        }
        else
        {
            return new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
        }
    }

    public IEnumerator SpawnObjectsRoutine()
    {
        while (true)
        {
            SpawnObjects(gamePointPrefab.gameObject, gameObstaclePrefab.gameObject);
            yield return new WaitForSeconds(0.8f);
        }
    }

    public IEnumerator CarVoice()
    {
        while (true)
        {
            FindObjectOfType<SoundManager>().Play("CarVoice");
            yield return new WaitForSeconds(6);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        Debug.Log("SceneChanged");
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Debug.Log("SceneChanged");
    }
}

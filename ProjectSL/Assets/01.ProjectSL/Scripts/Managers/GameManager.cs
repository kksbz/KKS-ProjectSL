using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject playerLeftArm;
    public GameObject playerRightArm;
    public GameObject player;

    //! 씬 로드하는 코루틴함수
    public IEnumerator LoadScene(string sceneName)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    } // LoadScene
} // GameManager

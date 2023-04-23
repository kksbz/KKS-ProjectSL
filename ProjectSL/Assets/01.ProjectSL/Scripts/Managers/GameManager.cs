using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject playerLeftArm;
    public GameObject playerRightArm;
    public GameObject player;

    //! �� �ε��ϴ� �ڷ�ƾ�Լ�
    public IEnumerator LoadScene(string sceneName)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    } // LoadScene
} // GameManager

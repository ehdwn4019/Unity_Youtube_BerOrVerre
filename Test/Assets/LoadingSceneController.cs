using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField]
    Image progressdBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // 비동기 씬 로드방식
        op.allowSceneActivation = false; // false이면 90퍼에서 멈추고 true되면 나머지 10퍼채워져서 100퍼까지 채워짐, 씬로딩이 빠른경우 또는 에셋번들 로딩할경우 사용 

        float timer = 0f;

        while(op.isDone)
        {
            yield return null;

            if(op.progress < 0.9f)
            {
                progressdBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressdBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer); //선형보간 
                if(progressdBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}

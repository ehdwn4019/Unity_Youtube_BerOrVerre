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
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); // �񵿱� �� �ε���
        op.allowSceneActivation = false; // false�̸� 90�ۿ��� ���߰� true�Ǹ� ������ 10��ä������ 100�۱��� ä����, ���ε��� ������� �Ǵ� ���¹��� �ε��Ұ�� ��� 

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
                progressdBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer); //�������� 
                if(progressdBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}

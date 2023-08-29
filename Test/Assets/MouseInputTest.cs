using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //마우스 휠 이벤트, 두개 동일 
        float value = Input.GetAxis("Mouse ScrollWheel"); // 휠을 1틱만 당길 시에 0.1씩 증가
        Vector2 scrollDelta = Input.mouseScrollDelta; // 휠을 1틱만 당길 시에 1씩 증가 


        Vector2 scrollPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y < 0)
        {
            Debug.Log("아래로 돌림 : " + Input.mousePosition.y);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            Debug.Log("위로 돌림 : " + Input.mousePosition.y);
        }



        Zoom();


    }

    /// <summary>
    /// 마우스 위치로 캐릭터 방향 이동
    /// </summary>
    public void LookMouseCursor()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitResult))
        {
            //Y값은 고정하지 않으면 Y값을 바라보기 위해 오브젝트가 기울어지는 문제 발생 
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }

    /// <summary>
    /// 줌인, 줌아웃
    /// </summary>
    public void Zoom()
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Input.mouseScrollDelta.y, 30f, 70f);
    }
}

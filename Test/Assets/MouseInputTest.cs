using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //���콺 �� �̺�Ʈ, �ΰ� ���� 
        float value = Input.GetAxis("Mouse ScrollWheel"); // ���� 1ƽ�� ��� �ÿ� 0.1�� ����
        Vector2 scrollDelta = Input.mouseScrollDelta; // ���� 1ƽ�� ��� �ÿ� 1�� ���� 


        Vector2 scrollPosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y < 0)
        {
            Debug.Log("�Ʒ��� ���� : " + Input.mousePosition.y);
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            Debug.Log("���� ���� : " + Input.mousePosition.y);
        }



        Zoom();


    }

    /// <summary>
    /// ���콺 ��ġ�� ĳ���� ���� �̵�
    /// </summary>
    public void LookMouseCursor()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitResult))
        {
            //Y���� �������� ������ Y���� �ٶ󺸱� ���� ������Ʈ�� �������� ���� �߻� 
            Vector3 mouseDir = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
            transform.forward = mouseDir;
        }
    }

    /// <summary>
    /// ����, �ܾƿ�
    /// </summary>
    public void Zoom()
    {
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - Input.mouseScrollDelta.y, 30f, 70f);
    }
}

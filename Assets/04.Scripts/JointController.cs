using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    /// <summary>
    /// �θ� ���� Ʈ������
    /// </summary>
    Transform parentTransform;
    /// <summary>
    /// �� ��ũ��Ʈ�� ���Ե� �� ������Ʈ�� ������ �ٵ�
    /// </summary>
    Rigidbody boneRigidbody;
    /// <summary>
    /// ���� �����ӱ����� �θ� ���� ��ġ
    /// </summary>
    Vector3 prevFrameParentPosition = Vector3.zero;
    /// <summary>
    /// ���� ����ġ
    /// </summary>
    public float power = 800f;
    /// <summary>
    /// ����� ��ġ�� ũ���� ����. ���� ���� �ʹ� ũ�� �� ���� ����� ������ ���ؼ�
    /// �� �������� �̻��� ��ġ�� ���ư��� ������ �߻��� �� �ִ�.
    /// </summary>
    public float clampDist = 0.03f;

    void Start()
    {
        parentTransform = transform.parent;
        prevFrameParentPosition = parentTransform.position;

        boneRigidbody = GetComponent<Rigidbody>();

        StartCoroutine(EarForce());
    }

    void FixedUpdate()
    {
        Vector3 delta = (prevFrameParentPosition - parentTransform.position);
        //Debug.Log(Vector3.ClampMagnitude(delta, clampDist) * power);
        boneRigidbody.AddForce(Vector3.ClampMagnitude(delta, clampDist) * power);

        prevFrameParentPosition = parentTransform.position;
    }

    IEnumerator EarForce()
    {
        while (true)
        {
            boneRigidbody.AddForce(new Vector3(0, 120f, 0));
            prevFrameParentPosition = parentTransform.position;
            yield return new WaitForSeconds(1.5f);
        }
        
    }
}

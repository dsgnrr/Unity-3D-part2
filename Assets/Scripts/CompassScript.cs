using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassScript : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject coin;

    private GameObject arrow;

    void Start()
    {
        arrow = GameObject.Find("CompassArrow");
    }

    void Update()
    {
        Vector3 toCoin = coin.transform.position - character.transform.position;
        toCoin.y = 0;  // ������� - ���������� ������� �� ���� �������
                       // ������ �� ���� �������� ��� � ����������� ������
                       // character.transform.forward ����������� �������������� � CharacterScript
        arrow.transform.eulerAngles = new Vector3(0, 0,
           Vector3.SignedAngle(
            character.transform.forward,
            toCoin,
            Vector3.down));
    }
}

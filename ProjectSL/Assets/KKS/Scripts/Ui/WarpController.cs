using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WarpController : MonoBehaviour
{
    [SerializeField] private GameObject warpSlotPrefab; // �������� ������
    [SerializeField] private Button exitBt; // ������ ��ư
    [SerializeField] private GameObject warpSlotList; // �������� �θ������Ʈ
    [SerializeField] GameObject selectPanel; // �����г�
    [SerializeField] GameObject warpPanel; // �����г�
    public GameObject warpSelect; // �������� �г�
    private Button warpSelectBt; // �������� �г� ���ù�ư
    private Button warpSelectExitBt; // �������� �г� �������ư
    public List<BonfireData> bonfireList = new List<BonfireData>(); // ȭ��� ����Ʈ
    public WarpSlot selectWarp; // ������ ��������

    // Start is called before the first frame update
    void Start()
    {
        warpSelectBt = warpSelect.transform.Find("SelectBt").GetComponent<Button>();
        warpSelectExitBt = warpSelect.transform.Find("ExitBt").GetComponent<Button>();

        exitBt.onClick.AddListener(() =>
        {
            warpPanel.SetActive(false);
            selectPanel.SetActive(true);
        });

        warpSelectBt.onClick.AddListener(() =>
        {
            // �÷��̾��� ��ġ�� ������ ȭ��� ��ġ�� �̵���Ŵ
            StartCoroutine(GameManager.Instance.LoadScene(selectWarp.bonfire));
            warpSelect.SetActive(false);
            warpPanel.SetActive(false);
        });

        warpSelectExitBt.onClick.AddListener(() =>
        {
            warpSelect.SetActive(false);
        });
    } // Start

    private void OnDisable()
    {
        Debug.Log("������Ʈ�ѷ� ��Ȱ��ȭ!");
    }

    //! �������� �����ϴ� �Լ�
    public void CreateWarpSlot(BonfireData _bonfire)
    {
        GameObject warpSlot = Instantiate(warpSlotPrefab);
        warpSlot.transform.parent = warpSlotList.transform;
        warpSlot.GetComponent<WarpSlot>().bonfire = _bonfire;
    } // CreateWarpSlot
} // WarpController

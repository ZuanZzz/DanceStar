using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanelView : MonoBehaviour
{
    public GameObject GamePanel;//当前挂载的面板
    public GameObject KeySlot;//按键槽
    public GameObject KeyPrefab;//按键预制体
    public GameObject PointerScrollBar;//滑动指针
    public Scrollbar PointerComponent;//滑动指针组件
    public GameObject Score;//分数
    public TextMeshProUGUI ScoreText;//分数文本
    public GameObject Level;//等级评价

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GamePanel = transform.gameObject;
        KeySlot = transform.Find("KeySlot").gameObject;
        KeyPrefab = Resources.Load<GameObject>("Prefabs/Key");
        PointerScrollBar = transform.Find("PointerScrollBar").gameObject;
        PointerComponent = PointerScrollBar.GetComponent<Scrollbar>();
        Score = transform.Find("Score").gameObject;
        ScoreText = Score.GetComponent<TextMeshProUGUI>();
        Level = transform.Find("Level").gameObject;

    }


    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score;
        //可以在这里添加分数变化的动画
    }
    public void UpdateLevel(string level)
    {
        Level.GetComponent<TextMeshProUGUI>().text = level;
    }
    public void UpdatePointer(float speed)
    {
        PointerComponent.value += Time.deltaTime * speed;
    }
    public void UpdateKey(List<GameObject> KeyPrefabList, int keyIndex)
    {
        KeyPrefabList[keyIndex].GetComponent<Image>().color = new Color32(138, 124, 156, 255);
        // keyIndex++;
        Debug.Log("left Arrow Key Pressed");
        Debug.Log("Key Index: " + keyIndex);

    }

    /// <summary>
    /// 更新下一组按键序列
    /// </summary>
    /// <param name="keySeq">箭头数据数组</param>
    /// <param name="KeyPrefabList">箭头预制体列表</param>
    public void UpdateNextKeySuquence(int[] keySeq, List<GameObject> KeyPrefabList)
    {
        Debug.Log("UpdateNextKeySuquence");

        foreach (Transform child in KeySlot.transform)
        {
            child.gameObject.SetActive(false);
        }

        InitKeySequence(keySeq, KeyPrefabList);
    }

    public void InitKeySequence(int[] keySeq, List<GameObject> KeyPrefabList)
    {
        KeyPrefabList.Clear();
        Debug.Log("InitKeySequence");
        for (int i = 0; i < keySeq.Length; i++)
        {
            GameObject keyInstance = Instantiate(KeyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            keyInstance.transform.SetParent(KeySlot.transform);
            KeyPrefabList.Add(keyInstance);
            switch (keySeq[i])
            {
                case 1:
                    keyInstance.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    break;
                case 2:
                    keyInstance.transform.localRotation = Quaternion.Euler(0, 0, -90);
                    break;
                case 3:
                    keyInstance.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
                case 4:
                    keyInstance.transform.localRotation = Quaternion.Euler(0, 0, 180);
                    break;
                default:
                    Debug.LogError("Invalid key value: " + keySeq[i]);
                    break;
            }

        }
    }

    public void ResetKeySequence(List<GameObject> KeyPrefabList)
    {
        //keyList所有图片恢复颜色
        foreach (GameObject key in KeyPrefabList)
        {
            key.GetComponent<Image>().color = Color.white;
        }
    }

}

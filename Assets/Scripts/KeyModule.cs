using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class KeyModule : MonoBehaviour
{
    public KeyQueue keyQueue;
    int keyIndex = 0;
    int listIndex = 0;
    public bool isFinished = false;
    private GameObject key;
    public GameObject KeySlot;
    List<GameObject> keyList = new List<GameObject>();
    void Awake()
    {
        //获取KeyQueue脚本scriptableobject
        keyQueue = Resources.Load<KeyQueue>("ScriptableObjects/KeyQueue");
        if (keyQueue == null)
        {
            Debug.LogError("KeyQueue scriptable object not found in Resources folder.");
        }
        key = Resources.Load<GameObject>("Prefabs/Key");
        if (key == null)
        {
            Debug.LogError("Key prefab not found in Resources folder.");
        }
        InitKeyQueue(keyQueue.KeyQueueList[listIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame && keyIndex <= keyQueue.KeyQueueList[listIndex].Length)
        {
            Debug.Log("Any Key Pressed");
            switch (keyQueue.KeyQueueList[listIndex][keyIndex])
            {
                case 1:
                    if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
                    {
                        //当前图片变色s
                        keyList[keyIndex].GetComponent<Image>().color = new Color32(138, 124, 156, 255);
                        keyIndex++;
                        Debug.Log("left Arrow Key Pressed");
                        Debug.Log("Key Index: " + keyIndex);
                    }
                    else
                    {
                        keyIndex = 0;
                        //keyList所有图片恢复颜色
                        foreach (GameObject key in keyList)
                        {
                            key.GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;
                case 2:
                    if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
                    {
                        keyList[keyIndex].GetComponent<Image>().color = new Color32(138, 124, 156, 255);
                        keyIndex++;
                        Debug.Log("right Arrow Key Pressed");
                    }
                    else
                    {
                        keyIndex = 0;
                        //keyList所有图片恢复颜色
                        foreach (GameObject key in keyList)
                        {
                            key.GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;
                case 3:
                    if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                    {
                        keyList[keyIndex].GetComponent<Image>().color = new Color32(138, 124, 156, 255);
                        keyIndex++;
                        Debug.Log("Up Arrow Key Pressed");
                    }
                    else
                    {
                        keyIndex = 0;
                        //keyList所有图片恢复颜色
                        foreach (GameObject key in keyList)
                        {
                            key.GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;
                case 4:
                    if (Keyboard.current.downArrowKey.wasPressedThisFrame)
                    {
                        keyList[keyIndex].GetComponent<Image>().color = new Color32(138, 124, 156, 255);
                        keyIndex++;
                        Debug.Log("Down Arrow Key Pressed");
                    }
                    else
                    {
                        keyIndex = 0;
                        //keyList所有图片恢复颜色
                        foreach (GameObject key in keyList)
                        {
                            key.GetComponent<Image>().color = Color.white;
                        }
                    }
                    break;
                default:
                    Debug.LogError("Invalid key value: " + listIndex);
                    break;
            }
        }
        else if (keyIndex >= keyQueue.KeyQueueList[listIndex].Length && listIndex < keyQueue.KeyQueueList.Count)
        {
            isFinished = true;
        }
        else
        {
            Debug.Log("All Key Sequences Completed");
            // Optionally, you can reset the listIndex to 0 or take any other action
            // listIndex = 0;
        }
    }

    public void InitKeyQueue(int[] keys)
    {
        keyList.Clear();
        for (int i = 0; i < keys.Length; i++)
        {
            GameObject keyInstance = Instantiate(key, new Vector3(0, 0, 0), Quaternion.identity);
            keyInstance.transform.SetParent(KeySlot.transform);
            keyList.Add(keyInstance);
            switch (keys[i])
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
                    Debug.LogError("Invalid key value: " + keys[i]);
                    break;
            }

        }
    }

    public void NextKeyQueue()
    {
        isFinished = false;
        Debug.Log("Key Sequence Completed, new listIndex: " + listIndex);
        //销毁当前所有的key
        foreach (Transform child in KeySlot.transform)
        {
            child.gameObject.SetActive(false);
        }
        listIndex++;
        keyIndex = 0;
        if (listIndex < keyQueue.KeyQueueList.Count)
            InitKeyQueue(keyQueue.KeyQueueList[listIndex]);
        else
        {
            Debug.Log("All  Completed");
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

//当 指针滑动到末端 按下空格键 
//会更新 分数、评价、箭头、指针
public class GamePanelController : MonoBehaviour
{
    int keyIndex = 0;
    int listIndex = 0;
    GamePanelView gamePanelView;
    GameModel gameModel;
    KeyQueue keyQueue;

    void Awake()
    {
        keyIndex = 0;
        listIndex = 0;
        //获取KeyQueue脚本scriptableobject
        keyQueue = Resources.Load<KeyQueue>("ScriptableObjects/KeyQueue");
        if (keyQueue == null)
        {
            Debug.LogError("KeyQueue scriptable object not found in Resources folder.");
        }
    }
    void Start()
    {
        gamePanelView = GetComponent<GamePanelView>();
        gameModel = new GameModel();
        gamePanelView.PointerComponent.value = 0f;
        gamePanelView.InitKeySequence(keyQueue.KeyQueueList[listIndex], keyQueue.KeyPrefabList);
    }

    void Update()
    {
        gamePanelView.UpdatePointer(gameModel.speed);
        //监听
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if (!Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                InputJudgement();
            }
            else
            {
                UpdateState();
            }
            if (keyIndex >= keyQueue.KeyQueueList[listIndex].Length - 1)
            {
                gameModel.isFinished = true;
            }
        }
        else if (gamePanelView.PointerComponent.value >= 1f)
        {
            UpdateState();
        }
    }
    void InputJudgement()
    {
        Debug.Log("Any Key Pressed");
        switch (keyQueue.KeyQueueList[listIndex][keyIndex])
        {
            case 1:
                if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
                {
                    gamePanelView.UpdateKey(keyQueue.KeyPrefabList, keyIndex);
                    keyIndex++;
                }
                else
                {
                    keyIndex = 0;
                    gamePanelView.ResetKeySequence(keyQueue.KeyPrefabList);
                }
                break;
            case 2:
                if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
                {
                    gamePanelView.UpdateKey(keyQueue.KeyPrefabList, keyIndex);
                    keyIndex++;
                }
                else
                {
                    keyIndex = 0;
                    gamePanelView.ResetKeySequence(keyQueue.KeyPrefabList);
                }
                break;
            case 3:
                if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                {
                    gamePanelView.UpdateKey(keyQueue.KeyPrefabList, keyIndex);
                    keyIndex++;
                }
                else
                {
                    keyIndex = 0;
                    gamePanelView.ResetKeySequence(keyQueue.KeyPrefabList);
                }
                break;
            case 4:
                if (Keyboard.current.downArrowKey.wasPressedThisFrame)
                {
                    gamePanelView.UpdateKey(keyQueue.KeyPrefabList, keyIndex);
                    keyIndex++;
                }
                else
                {
                    keyIndex = 0;
                    gamePanelView.ResetKeySequence(keyQueue.KeyPrefabList);
                }
                break;
            default:
                Debug.LogError("Invalid key value: " + listIndex);
                break;
        }

    }


    void UpdateState()
    {
        //判断等级
        int level = gameModel.isFinished ? GetLevel.GetSocre(gamePanelView.PointerComponent.value) : 4;
        //计算分数
        GetLevel.SetScoreLevel(level, gameModel.score, gameModel.level);
        //更新分数文本
        gamePanelView.UpdateScore(gameModel.score);
        gamePanelView.UpdateLevel(gameModel.level);
        //重置箭头、指针
        gameModel.isFinished = false;
        keyIndex = 0;
        gamePanelView.PointerComponent.value = 0f;
        listIndex++;
        gamePanelView.UpdateNextKeySuquence(keyQueue.KeyQueueList[listIndex], keyQueue.KeyPrefabList);
    }



}

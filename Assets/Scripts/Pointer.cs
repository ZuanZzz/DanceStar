using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public KeyModule keyModule;
    public GameObject PointerGameObject;
    public Scrollbar pointerScrollbar;
    public float speed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //获取Scrollbar组件
        pointerScrollbar = GetComponent<Scrollbar>();
        if (pointerScrollbar == null)
        {
            Debug.LogError("Scrollbar component not found on this GameObject.");
        }
        pointerScrollbar.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //scrollbar.value自动随时间移动
        pointerScrollbar.value += Time.deltaTime * speed;
        if (pointerScrollbar.value >= 1f || Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (keyModule.isFinished)
            {
                GetSocre();
            }
            else
            {
                Miss();
                Debug.Log("KeyModule is not finished");
            }


            //如果scrollbar.value大于等于1，且按下任意键，则重置scrollbar.value为0
            pointerScrollbar.value = 0f;

            keyModule.NextKeyQueue();

        }


    }

    public void GetSocre()
    {
        if (pointerScrollbar.value >= 0.823f && pointerScrollbar.value <= 0.829f)
        {
            Debug.Log("Perfect");
            levelText.text = "Perfect";
            score += 100;
            scoreText.text = "Score: " + score;
        }
        else if (
            (pointerScrollbar.value >= 0.775f && pointerScrollbar.value < 0.823f)
            || (pointerScrollbar.value >= 0.829f && pointerScrollbar.value < 0.9f))
        {
            Debug.Log("Great");
            levelText.text = "Great";
            score += 80;
            scoreText.text = "Score: " + score;
        }
        else if ((pointerScrollbar.value >= 0.7f && pointerScrollbar.value < 0.775f)
            || (pointerScrollbar.value >= 0.9f && pointerScrollbar.value < 1f))
        {
            Debug.Log("Good");
            levelText.text = "Good";
            score += 60;
            scoreText.text = "Score: " + score;
        }
        else if (pointerScrollbar.value >= 0.6f && pointerScrollbar.value < 0.7f)
        {
            Debug.Log("OK");
            levelText.text = "OK";
            score += 40;
            scoreText.text = "Score: " + score;
        }
        else
        {
            Miss();
        }
    }

    public void Miss()
    {
        Debug.Log("Poniter Scrollbar Value: " + pointerScrollbar.value);
        Debug.Log("Miss");
        levelText.text = "Miss";
        score += 0;
        scoreText.text = "Score: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonAnalyse : MonoBehaviour
{
    [System.Serializable]
    public class BeatData
    {
        public float tempo;
        public List<float> beatTimes;
    }

    private BeatData beatData;
    private float timer = 0f;
    private int currentBeatIndex = 0;
    private bool isScaling = false;

    void Start()
    {
        // 正确路径：Resources/DataFiles/beat_data.json -> "DataFiles/beat_data"
        TextAsset jsonFile = Resources.Load<TextAsset>("DataFiles/beat_data");

        if (jsonFile != null)
        {
            beatData = JsonUtility.FromJson<BeatData>(jsonFile.text);
            Debug.Log("Tempo: " + beatData.tempo);
            Debug.Log("First Beat Time: " + beatData.beatTimes[0]);
        }
        else
        {
            Debug.LogError("Failed to load JSON file.");
        }
    }

    void Update()
    {
        if (beatData == null || beatData.beatTimes == null || currentBeatIndex >= beatData.beatTimes.Count)
            return;

        timer += Time.deltaTime;

        float nextBeatTime = beatData.beatTimes[currentBeatIndex];

        // 判断是否到了节拍时间（允许一定误差）
        if (timer >= nextBeatTime - 0.01f)
        {
            Debug.Log("Beat at: " + nextBeatTime);
            StartCoroutine(FlashScale());
            currentBeatIndex++;
        }
    }

    // 缩放闪烁效果（协程）
    IEnumerator FlashScale()
    {
        if (isScaling) yield break;
        isScaling = true;

        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.5f;

        // 缩放到 1.5 倍
        transform.localScale = targetScale;
        yield return new WaitForSeconds(0.01f);

        // 还原
        transform.localScale = originalScale;
        isScaling = false;
    }
}

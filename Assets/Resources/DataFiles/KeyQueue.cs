using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeKeyQueueListyQueue", menuName = "Scriptable Objects/KeyQueue")]
public class KeyQueue : ScriptableObject
{
    [SerializeField]

    public List<int[]> KeyQueueList = new List<int[]>();
    public List<GameObject> KeyPrefabList;

    private void OnEnable()
    {
        KeyQueueList.Clear();
        KeyQueueList.Add(new int[7] { 1, 2, 3, 4, 1, 2, 3 });
        KeyQueueList.Add(new int[7] { 4, 3, 2, 1, 4, 3, 2 });
        KeyQueueList.Add(new int[7] { 1, 2, 3, 4, 1, 2, 3 });
        KeyQueueList.Add(new int[7] { 4, 3, 2, 1, 4, 3, 2 });
        KeyQueueList.Add(new int[7] { 1, 2, 3, 4, 1, 2, 3 });
        KeyQueueList.Add(new int[7] { 4, 3, 2, 1, 4, 3, 2 });
        KeyQueueList.Add(new int[4] { 1, 2, 1, 2 });
        KeyQueueList.Add(new int[4] { 2, 1, 2, 1 });
        KeyQueueList.Add(new int[4] { 3, 4, 3, 4 });
        KeyQueueList.Add(new int[4] { 4, 3, 4, 3 });
        KeyQueueList.Add(new int[2] { 1, 2 });
    }
}

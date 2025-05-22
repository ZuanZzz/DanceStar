using UnityEngine;

public class GameModel
{
    public int score = 0;

    public string level = null;

    public float speed = 0.4f;
    public bool isFinished = true;

    //单例模式
    private static GameModel instance;
    public static GameModel Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameModel();
            }
            return instance;
        }
    }


}

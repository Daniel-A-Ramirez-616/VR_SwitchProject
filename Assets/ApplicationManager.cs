using Unity.VisualScripting;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public int playerNumber = 0;
    public static ApplicationManager application;

    private void Awake()
    {
        application = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerNumber(int controlNumber)
    {
        playerNumber = controlNumber;
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}

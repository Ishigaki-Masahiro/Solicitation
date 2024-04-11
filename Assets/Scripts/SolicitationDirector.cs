using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolicitationDirector : MonoBehaviour
{
    // ResultPanel
    [SerializeField] GameObject resultPanel;

    // SetumeiPanel
    [SerializeField] GameObject setumeiPanel;

    // titlePanel
    [SerializeField] GameObject titlePanel;

    // SavePanel
    [SerializeField] GameObject savePanel;

    // OptionPanel
    [SerializeField] GameObject optionPanel;

    // QuitPanel
    [SerializeField] GameObject quitPanel;

    [Header("CountDownTimer")]
    [SerializeField] CountDownTimer countDownTimer;

    // �Q�[�����[�h
    enum GameMode
    {
        Prologue,
        Title,
        Game,
        End1,
        End2,
        Result,
    }

    GameMode gameMode;

    private enum SceneTimer
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    void Start()
    {
        Time.timeScale = 1;

        titlePanel.SetActive(true);

        setumeiPanel.SetActive(false);
        resultPanel.SetActive(false);
        savePanel.SetActive(false);
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);

        // �ŏ��̃��[�h
        gameMode = GameMode.Prologue;
    }

    void Update()
    {
        switch (gameMode)
        {
            case GameMode.Prologue:
                PrologueMode();
                break;
            case GameMode.Title:
                TitleMode();
                break;
            case GameMode.Game:
                GamingMode();
                break;
            case GameMode.End1:
                End1Mode();
                break;
            case GameMode.End2:
                End2Mode();
                break;
            case GameMode.Result:
                ResultMode();
                break;
            default:
                break;
        }
    }

    private void GameResult()
    {
        resultPanel.SetActive(true);
        enabled = false; // Stop updating
    }

    void Setumei()
    {
        setumeiPanel.SetActive(!setumeiPanel.activeSelf);
        SceneFlagManager.Instance.isPlayerMoving = !setumeiPanel.activeSelf;
    }

    void PrologueMode()
    {
        gameMode = GameMode.Title;
        Debug.Log(gameMode);
    }

    void TitleMode()
    {
        //Debug.Log(gameMode);
    }

    public void TitleButton()
    {
        titlePanel.SetActive(!titlePanel.activeSelf);
        SceneFlagManager.Instance.isPlayerMoving = !titlePanel.activeSelf;
        gameMode = GameMode.Game;
    }

    public void QuitButton()
    {
        quitPanel.SetActive(!quitPanel.activeSelf);
    }

    public void QuitPanel()
    {
        Application.Quit();
    }

    void GamingMode()
    {
        if(ItemText.instance.isComp)  // �i�{�[����S�ĊJ������
        {
            countDownTimer.TimerUpdate();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Setumei();
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionPanel.SetActive(!optionPanel.activeSelf);
            SceneFlagManager.Instance.isPlayerMoving = !optionPanel.activeSelf;
        }
    }

    public void SaveButton()
    {
        savePanel.SetActive(!savePanel.activeSelf);
    }

    public void OptionButton(int timeScale)
    {
        Time.timeScale = timeScale;
        titlePanel.SetActive(!titlePanel.activeSelf);
        optionPanel.SetActive(!optionPanel.activeSelf);
    }

    void End1Mode()
    {
        Debug.Log(gameMode);
    }

    void End2Mode()
    {
        Debug.Log(gameMode);
    }

    void ResultMode()
    {
        Debug.Log(gameMode);
    }

    // ���g���C�{�^���������ꂽ���̏���
    public void OnClickRetry()
    {
        SceneManager.LoadScene("SolicitationScene");
    }
}

[System.Serializable]
public class Sun
{
    [Header("�����ڂ�")]
    public bool isAGE; // �����Ƃ�isAGE���

    // �e���ɈقȂ镔���ɕω����N�����t���O�̃��X�g
    [Header("�����ɕω����N�����t���O")]
    public List<RoomFlag> roomFlags = new List<RoomFlag>();
}

[System.Serializable]
public class RoomFlag
{
    [Header("�����ٕ̈ς��N�����t���O")]
    public bool isActive;
}
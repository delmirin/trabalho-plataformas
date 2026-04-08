
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public GameState estadoAtual;

    private PlayerInput playerInput;

    private void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        MudarEstado(GameState.Iniciando);
        CarregarCena("Splash");
    }

    public void MudarEstado(GameState novoEstado)
    {
        estadoAtual = novoEstado;
        Debug.Log("Estado atual: " + estadoAtual);
    }

    public void CarregarCena(string nomeCena)
    {
        // Controle de acesso ao SceneManager
        SceneManager.LoadScene(nomeCena);

        // Atualiza estado conforme a cena
        if (nomeCena == "MenuPrincipal")
            MudarEstado(GameState.MenuPrincipal);
        else if (nomeCena == "SampleScene")
            MudarEstado(GameState.Gameplay);
    }

    // Alocação de Input
    public void ConfigurarInput(PlayerInput input)
    {
        playerInput = input;
    }

    // Botão de sair
    public void SairJogo()
    {
        Application.Quit();
    }
}
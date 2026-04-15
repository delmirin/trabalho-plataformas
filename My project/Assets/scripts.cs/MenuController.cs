using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void IniciarJogo()
    {
        GameManager.instance.CarregarCena("SampleScene");
    }

    public void Sair()
    {
        GameManager.instance.SairJogo();
    }
}
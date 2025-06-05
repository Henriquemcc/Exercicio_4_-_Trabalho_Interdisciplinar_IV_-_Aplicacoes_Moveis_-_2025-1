using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    // Texto que mostra as moedas do jogador
    public Text coinsDisplayText;

    // Player
    public GameObject player;

    private PlayerBehaviour playerBehaviour;

    void Awake()
    {
        // Obtendo o player behaviour
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    void Update()
    {
        if (playerBehaviour != null)
        {
            // Exibe o valor atualizado das moedas do jogador
            coinsDisplayText.text = playerBehaviour.coins.ToString();
        }
    }
}
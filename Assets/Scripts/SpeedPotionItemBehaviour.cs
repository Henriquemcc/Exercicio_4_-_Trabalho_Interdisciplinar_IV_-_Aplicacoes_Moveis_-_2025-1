using System.Collections;
using UnityEngine;

// Comportamento do item do tipo poção de velocidade
class SpeedPotionItemBehaviour : CollectibleItemBehaviour
{
    public float speedMoveIncrement = 20;
    public float speedMoveIncrementTimeOut = 4;

    public void OnTriggerEnter(Collider collider)
    {
        if (((1 << collider.gameObject.layer) & playerLayer.value) != 0)
        {
            // Mensagem de debug
            Debug.Log("Colidido com o player");

            // Obtendo playerBehaviour de player
            PlayerBehaviour playerBehaviour = collider.gameObject.GetComponent<PlayerBehaviour>();
            if (playerBehaviour != null)
            {
                // Incrementando a velocidade do player
                IncreasePlayerMoveSpeed(playerBehaviour);

                // Deletando item
                Destroy(gameObject);
            }
        }
    }

    // Incrementa a velocidade de movimentação do player
    private void IncreasePlayerMoveSpeed(PlayerBehaviour playerBehaviour)
    {
        // Incrementando a velocidade de movimentação do player
        playerBehaviour.moveSpeed += speedMoveIncrement;

        // Voltando a velocidade padrão
        StartCoroutine(ReturnToPreviousSpeed(playerBehaviour));
    }

    // Volta a velocidade de movimentação padrão após o timeout
    private IEnumerator ReturnToPreviousSpeed(PlayerBehaviour playerBehaviour)
    {
        yield return new WaitForSeconds(speedMoveIncrementTimeOut);
        playerBehaviour.moveSpeed = playerBehaviour.defaultMoveSpeed;
    }
}
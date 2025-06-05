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
                playerBehaviour.TemporarilyIncrementMoveSpeed(speedMoveIncrement, speedMoveIncrementTimeOut);

                // Deletando item
                Destroy(gameObject);
            }
        }
    }
}
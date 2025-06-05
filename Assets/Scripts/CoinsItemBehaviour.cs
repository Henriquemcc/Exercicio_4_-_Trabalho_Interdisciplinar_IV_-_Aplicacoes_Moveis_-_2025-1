using UnityEngine;

class CoinsItemBehaviour : CollectibleItemBehaviour
{
    // Valor da moeda
    public int value;

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
                // Incrementando a moeda do player
                playerBehaviour.IncrementCoins(value);

                // Deletando item
                Destroy(gameObject);
            }
        }
    }
}

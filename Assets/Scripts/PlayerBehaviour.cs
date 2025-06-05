using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    // Velocidade de Movimentação
    [Header("Velocidade de Movimentação")]
    public float moveSpeed = 5;

    // Moedas do jogador
    [Header("Moedas do Jogador")]
    public int coins = 0;

    // Componente responsável por simular a gravidade e realizar movimentação do player
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        // Obtendo movimentação da entrada
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Aplicando movimento ao player
        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed;
        _rigidbody.linearVelocity = new Vector3(movement.x, _rigidbody.linearVelocity.y, movement.z);
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    // Incrementa a velocidade de movimentação do player temporariamente
    public void TemporarilyIncrementMoveSpeed(float speedMoveIncrement, float timeOut)
    {
        // Incrementando a velocidade de movimentação do player
        moveSpeed += speedMoveIncrement;

        // Voltando a velocidade padrão
        StartCoroutine(DecrementMoveSpeed(timeOut, speedMoveIncrement));
    }

    // Volta a velocidade de movimentação padrão após o timeout
    private IEnumerator DecrementMoveSpeed(float timeOut, float speedMoveDecrement)
    {
        yield return new WaitForSeconds(timeOut);
        moveSpeed -= speedMoveDecrement;
    }

    // Incrementa as moedas do jogador
    public void IncrementCoins(int coinsIncrement)
    {
        if (coinsIncrement > 0)
        {
            coins += coinsIncrement;
        }
    }
}

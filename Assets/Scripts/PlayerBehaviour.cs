using System.Collections;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Propriedades de Movimentação")]

    // Velocidade de Movimentação
    public float defaultMoveSpeed = 5;
    public float moveSpeed;

    // Moedas do jogador
    public int coins;

    // Componente responsável por simular a gravidade e realizar movimentação do player
    private Rigidbody _rigidbody;

    private void Awake()
    {
        moveSpeed = defaultMoveSpeed;
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
    public void TemporarilyIncreaseMoveSpeed(float speedMoveIncrement, float timeOut)
    {
        // Incrementando a velocidade de movimentação do player
        moveSpeed += speedMoveIncrement;

        // Voltando a velocidade padrão
        StartCoroutine(ReturnToPreviousSpeed(timeOut));
    }

    // Volta a velocidade de movimentação padrão após o timeout
    private IEnumerator ReturnToPreviousSpeed(float timeOut)
    {
        yield return new WaitForSeconds(timeOut);
        moveSpeed = defaultMoveSpeed;
    }
}

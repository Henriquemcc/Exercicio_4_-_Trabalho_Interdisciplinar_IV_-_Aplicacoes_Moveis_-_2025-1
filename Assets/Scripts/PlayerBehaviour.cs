using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [Header("Propriedades de Movimentação")]

    // Velocidade de Movimentação
    public float defaultMoveSpeed = 5;
    public float moveSpeed;

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
}

using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

// Comportamento de um item coletável
abstract class CollectibleItemBehaviour : MonoBehaviour
{   
    public LayerMask playerLayer;
    public abstract void OnCollisionEnter(Collision other);
}

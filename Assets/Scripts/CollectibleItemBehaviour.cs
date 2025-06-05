using UnityEngine;

[RequireComponent(typeof(Collider))]

// Comportamento de um item coletável
abstract class CollectibleItemBehaviour : MonoBehaviour
{   
    public LayerMask playerLayer;
}

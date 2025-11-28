using UnityEngine;
using Unity.Netcode;

public class PlayerServerController : NetworkBehaviour
{
    // Position du pion synchronisée
    private NetworkVariable<Vector2> position2D = new NetworkVariable<Vector2>(
        writePerm: NetworkVariableWritePermission.Server);

    public float moveSpeed = 5f;

    void Update()
    {
        // Seul le client “owner” envoie des requêtes de déplacement
        if (!IsOwner) return;

        // Ex. : on lit l’input via un autre script, mais ici simple Input
        Vector2 input = new Vector2(
            Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0,
            Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0);

        if (input.sqrMagnitude > 0.01f)
        {
            

            // Envoie une RPC au serveur pour demander le move
            RequestMoveServerRpc(input);
        }
    }
//On est sur le serveur
    [ServerRpc]
    void RequestMoveServerRpc(Vector2 input, ServerRpcParams rpcParams = default)
    {
        //Variable synchronisée, pas besoin de vérifier le clientId
        //Variable synchronisée, il est appliquer sur le serveur parce que c'est une ServerRpc
        // Côté serveur : applique le mouvement
        Vector2 newPos = position2D.Value + input.normalized * moveSpeed * Time.deltaTime;
        position2D.Value = newPos;

        // Optionnel : tu peux aussi appeler un ClientRpc pour update immédiate,
        // mais NetworkVariable synchronise déjà automatiquement.
    }

    void LateUpdate()
    {
        // Tout le monde (serveur + clients) met à jour le transform visuel selon position2D
        transform.position = new Vector3(position2D.Value.x, position2D.Value.y, transform.position.z);
    }
}

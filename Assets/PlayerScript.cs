using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    
    [SerializeField]
    float rayLength = 3f;

    [SerializeField]
    LayerMask _layerMask;

    [SerializeField]
    Transform _playerCube;

    public TMP_Text uiText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_xFormToRayCastFrom == null) return;
        Debug.DrawRay(_playerCube.position, _playerCube.forward * rayLength, Color.red);
        if (Physics.Raycast(_playerCube.position, _playerCube.forward, out RaycastHit hit, rayLength, _layerMask))
        {
            uiText.text = "Press E to Intreact";
        }
        else
        {
            uiText.text = " ";
        }

        // raycast


            //Debug.DrawRay(transform.position, Vector3.forward * rayLength, Color.red);
            //return Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(_playerCube.position, _playerCube.forward, out RaycastHit hit, rayLength, _layerMask))
        {
            GameObject hitGo = hit.transform.gameObject;
            if (hitGo.TryGetComponent<IMyIntract>(out IMyIntract interactable))
            {
                interactable.MyIntract();
            }
        }
    }
    
}

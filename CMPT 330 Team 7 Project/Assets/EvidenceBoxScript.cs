using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class EvidenceBoxScript : MonoBehaviour
{
    private Animator _animator;
    private bool _isOpen;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _isOpen = false;
        _animator.Play("EvidenceBoxIdle");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_isOpen)
            {
                _animator.Play("EvidenceBoxClosing");
                _isOpen = false;
            }
            else
            {
                _animator.Play("EvidenceBoxOpening");
                _isOpen = true;
            }
        }
    }
}

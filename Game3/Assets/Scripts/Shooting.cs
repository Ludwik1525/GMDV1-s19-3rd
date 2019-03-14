using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletSpeed;
    private CharacterController2D _characterController;
    private SpriteRenderer _gunRenderer;
    private Transform _gunBarrelTransform;
    
    private void Awake()
    {
        _characterController = GetComponentInParent<CharacterController2D>();
        _gunRenderer = GetComponent<SpriteRenderer>();
        _gunBarrelTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    //N.B.: Unoptimized Code without object pooling!
    private void Update()
    {
        //Don't show the gun or allow shooting if the player is ducking
        if (_characterController.Ducking)
        {
            _gunRenderer.enabled = false;
            return;
        }

        _gunRenderer.enabled = true;

        //Fire bullets in the facing direction
        if (Input.GetButtonDown("X_" + _characterController.PlayerNumber))
        {
            var bullet = Instantiate(_bullet, _gunBarrelTransform.position, Quaternion.identity);
            
            var force = (_characterController.FacingRight ? Vector2.right : -Vector2.right) * _bulletSpeed;
            bullet.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
}
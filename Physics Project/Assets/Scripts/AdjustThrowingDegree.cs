using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace physics.Project
{
    public class AdjustThrowingDegree : MonoBehaviour
    {
        #region variables & references:

        [SerializeField] private GameObject _projectile;
        [SerializeField] private GameObject _dotGO;

        [SerializeField] private int _dotsNumber;

        [SerializeField] private float _launchForce;
        [SerializeField] private float _spaceBetweenDots;

        private Transform _shotingPivot;

        private Vector2 startDirection;

        private GameObject[] _dotsArray;

        #region getter & setter:

        public float LaunchForce { get => _launchForce; set => _launchForce = value; }

        #endregion

        #endregion

        #region main functions:

        private void Start() => Initialize();

        private void Update()
        {
            GetDirection();
        }

        #endregion

        #region private functions:

        private void Initialize()
        {
            _shotingPivot = this.transform;
            _dotsArray = new GameObject[_dotsNumber];
            for(int i = 0; i < _dotsNumber; i++)
            {
                _dotsArray[i] = Instantiate(_dotGO, _shotingPivot.position, Quaternion.identity);
            }
        }

        private void GetDirection()
        {
            startDirection = new Vector2(-_shotingPivot.position.x, this.transform.eulerAngles.z);

            for (int i = 0; i < _dotsNumber; i++)
            {
                _dotsArray[i].transform.position = DotPosition(i * _spaceBetweenDots);
            }
        }

        private Vector2 DotPosition(float time)
        {          
            Vector2 dotPosition = (Vector2)_shotingPivot.position + (startDirection.normalized * LaunchForce * time) + 0.5f * Physics2D.gravity * (time * time);
            return dotPosition;
        }

        private void ShootProjectile()
        {
            GameObject projectileGO = Instantiate(_projectile, _shotingPivot.position, _shotingPivot.rotation);
            projectileGO.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        }

        private void SetGameObjectRotation(float newDegree) => this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, newDegree);

        #endregion

        #region public functions:

        public void ProvokeDegreeChange(float value) => SetGameObjectRotation(value);

        public void ProvokeShootingProjectile() => ShootProjectile();

        #endregion
    }
}
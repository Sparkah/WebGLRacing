using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 100;
    [SerializeField] private float _inertion = 20;
    [SerializeField] private float _gravityForceModifier = 75;

    private float _horizontalSpeed;
    private float _verticalSpeed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.drag *= _inertion;
    }

    private void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
        _verticalSpeed = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Escape))
        {
            UIManagerScript.Instance.BackToMenu();
        }

        /*
         * reset PlayerPrefs
        if(Input.GetKey(KeyCode.Q))
        {
            PlayerPrefs.SetFloat("HighScore", 99999);
        }
        */
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(new Vector3(_verticalSpeed, 0, -_horizontalSpeed) * _moveSpeed);
        //Add exra gravity strenght to overcome the drag
        _rigidbody.AddForce(Vector3.down * _gravityForceModifier);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controler;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _gravity = 9.8f;

    [SerializeField] private GameObject _muzzleflash;

    [SerializeField] private GameObject _hitmarkprefab;
    [SerializeField] private AudioSource _weaponaudio;

    [SerializeField] private GameObject Weapon;

    [SerializeField] private int currentAmmo;
    private int maxAmmo = 50;
    private bool isreloading = false;
    private UIManager _uimanager;
    public bool hascoin = false;

    // Start is called before the first frame update
    void Start()
    {

        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _controler = GetComponent<CharacterController>();

        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        calculateMovement();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if(Input.GetKeyDown(KeyCode.R) && (isreloading == false)){
            isreloading = true;
            StartCoroutine(Reload());
        }

    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direciton = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direciton * _speed;
        velocity.y -= _gravity;

        velocity = transform.transform.TransformDirection(velocity);
        _controler.Move(velocity * Time.deltaTime);

    }

    void Shoot()
    {
        if (Input.GetMouseButton(0) && currentAmmo > 0)
        {

            Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            currentAmmo--;
            _uimanager.UpdateAmmo(currentAmmo);
            _muzzleflash.SetActive(true);
            if (_weaponaudio.isPlaying == false)
            {
                _weaponaudio.Play();
            }

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                Debug.Log("Ray cast hit: " + hitInfo.transform.name);
                Instantiate(_hitmarkprefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

                Destroy crate = hitInfo.transform.GetComponent<Destroy>();

                if(crate != null){
                    crate.Destroycrate();
                }

            }
        }
        else
        {
            _muzzleflash.SetActive(false);
            _weaponaudio.Stop();
        }
    }

    IEnumerator Reload() {
        yield return new WaitForSeconds(1.5f);
        currentAmmo = maxAmmo;
        _uimanager.UpdateAmmo(currentAmmo);
        isreloading = false;
    }

    public void EnableWeapon(){
        Weapon.SetActive(true);
    }


}

using System;
using System.Collections;
using UnityEngine;

public class Preview : MonoBehaviour
{
    public static Preview Instance;
    [SerializeField] private GameObject PreviewPrefab;
    public GameObject BuildPrefab;
    private bool _IsBuyAvailable;
    [SerializeField] private float CheckIsBuyAvailable_delay;

    SpriteRenderer sr;
    private bool _isBuildAvailable;
    public bool IsBuildAvailable
    {
        get { return _isBuildAvailable; }

        set
        {
            _isBuildAvailable = value && _IsBuyAvailable;
            sr.material.color = _isBuildAvailable ? colorOnAvailable : colorOnNotAvailable;
        }
    }

    public Color colorOnAvailable;
    public Color colorOnNotAvailable;

    private void Awake()
    {
        Instance = this;
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = BuildPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
        colorOnAvailable = new Color(0, 1f, .3f, .8f);
        colorOnNotAvailable = new Color(1, .2f, .2f, .8f);
    }

    private void Start()
    {
        StartCoroutine(CheckIsBuyAvailable(CheckIsBuyAvailable_delay));
    }

    public void moveToCursorPosition(Vector3 coords, Func<bool> isBuildAvailable)
    {
        transform.position = coords;
        IsBuildAvailable = isBuildAvailable();
    }

    public IEnumerator CheckIsBuyAvailable(float delay) // Тут не плохо, если не ref?
    {
        CheckIsBuyAvailable();
        yield return new WaitForSeconds(delay);
        StartCoroutine(CheckIsBuyAvailable(CheckIsBuyAvailable_delay));
    }

    public void CheckIsBuyAvailable()
    {
        int buildCost = BuildPrefab.GetComponent<Tower>().cost;
        _IsBuyAvailable = Player.Instance.money.IsBuyAvailable(buildCost);
    }

    public GameObject BuildHere(Func<bool> isBuildAvailable)
    {
        if (!isBuildAvailable() || !_isBuildAvailable) {
            IsBuildAvailable = false;
            return null;
        }

        return Instantiate(BuildPrefab, transform.position, Quaternion.identity);
    }
}
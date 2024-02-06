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
    
    public Color colorOnAvailable;
    public Color colorOnNotAvailable;

    private void Awake()
    {
        Instance = this;
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.sprite = BuildPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
        colorOnAvailable = new Color(0, 1f, .3f, .8f);
        colorOnNotAvailable = new Color(1, .2f, .2f, .8f);

        StartCoroutine(CheckIsBuyAvailable(CheckIsBuyAvailable_delay));
    }
    
    public void moveToCursorPosition(Vector3 coords, Func<bool> isBuildAvailable)
    {
        transform.position = coords;
        IsBuildAvailable = isBuildAvailable();
    }

    public IEnumerator CheckIsBuyAvailable(float delay)
    {
        CheckIsBuyAvailable();
        yield return new WaitForSeconds(CheckIsBuyAvailable_delay);
        StartCoroutine(CheckIsBuyAvailable(delay));
    }

    public void CheckIsBuyAvailable()
    {
        int buildCost = BuildPrefab.GetComponent<Tower>().cost;
        _IsBuyAvailable = Player.Instance.money.IsBuyAvailable(buildCost);
    }

    public bool IsBuildAvailable
    {
        get { return _isBuildAvailable; }

        set
        {
            _isBuildAvailable = value && _IsBuyAvailable;
            sr.material.color = _isBuildAvailable ? colorOnAvailable : colorOnNotAvailable;
        }
    }

    public GameObject BuildHere(Func<bool> isBuildAvailable)
    {
        if (!isBuildAvailable() || !_isBuildAvailable) return null;

        return Instantiate(BuildPrefab, transform.position, Quaternion.identity);
    }
}
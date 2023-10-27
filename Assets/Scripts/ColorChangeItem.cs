using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeItem : MonoBehaviour
{
    [SerializeField] private ColorChangeItemSO colorChangeItemSO;
    private CircleCollider2D circleCollider2D;
    private Rigidbody2D rigidbody2D;
    private Color randomColor;

    [SerializeField] private bool isFirst;
    [SerializeField] private GameObject colorChangeItemDetectorGameObject;
    private ColorChangeItemDetector colorChangeItemDetector;
    private void Awake()
    {
        randomColor = Color.black;
        circleCollider2D = GetComponent<CircleCollider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetComponentColors();
        if (isFirst)
        {
            GenerateRandomColor();
        }
        else
        {
            SpawnColorChangeItemDetector();
            colorChangeItemDetector.OnColorChangeItemFound += ColorChangeItemDetector_OnColorChangeItemFound;
        }
    }

    private void ColorChangeItemDetector_OnColorChangeItemFound(object sender, ColorChangeItemDetector.OnColorChangeItemFoundEventArgs e)
    {
        List<Color> ignoreColors = new List<Color> { e.colorChangeItem.GetColor() };
        randomColor = MyGameManager.Instance.GenerateRandomColor(ignoreColors);
        Destroy(colorChangeItemDetector.gameObject);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }

    public Color GetColor()
    {
        return randomColor;
    }

    public ColorChangeItemSO GetColorChangeItemSO()
    {
        return colorChangeItemSO;
    }
    private void GenerateRandomColor()
    {
        randomColor = MyGameManager.Instance.GenerateRandomColor();
    }

    private void SpawnColorChangeItemDetector()
    {
        GameObject item = Instantiate(colorChangeItemDetectorGameObject);
        colorChangeItemDetector = item.GetComponent<ColorChangeItemDetector>();
        Vector3 startingPos = new Vector3(this.transform.position.x, this.transform.position.y - 1f, this.transform.position.z);
        colorChangeItemDetector.SetStartingPosition(startingPos);
        item.transform.position = startingPos;
    }

    private void SetComponentColors()
    {
        int i = 0;
        foreach (Transform component in this.transform)
        {
            Color color = MyGameManager.Instance.GetColor(i);
            i++;
            component.GetComponent<SpriteRenderer>().color = color;
        }
    }

}
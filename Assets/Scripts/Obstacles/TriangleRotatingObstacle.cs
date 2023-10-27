using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRotatingObstacle : RotatingObstacle
   
{
    [SerializeField] private ObstacleComponent[] obstacleComponentList;
    [SerializeField] private GameObject colorChangeItemDetectorGameObject;
    private ColorChangeItemDetector colorChangeItemDetector;
    private ObstacleComponent randomComponent;

    private void Awake()
    {
        SpawnColorChangeItemDetector();
        randomComponent = SelectRandomComponent();
        colorChangeItemDetector.OnColorChangeItemFound += ColorChangeItemDetector_OnColorChangeItemFound;
    }
    private void Start()
    {
    }

    private void Update()
    {
        HandleRotation();
    }
    private void ColorChangeItemDetector_OnColorChangeItemFound(object sender, ColorChangeItemDetector.OnColorChangeItemFoundEventArgs e)
    {
        randomComponent.SetColor(e.colorChangeItem.GetColor());
        List<Color> ignoreColors = new List<Color>();
        ignoreColors.Add(e.colorChangeItem.GetColor());

        foreach (ObstacleComponent obstacleComponent in obstacleComponentList)
        {
            if (obstacleComponent != randomComponent)
            {
                Color tempColor = MyGameManager.Instance.GenerateRandomColor(ignoreColors);
                ignoreColors.Add(tempColor);
                obstacleComponent.SetColor(tempColor);
            }
        }

        Destroy(colorChangeItemDetector.gameObject);
    }

    private void SpawnColorChangeItemDetector()
    {
        GameObject item = Instantiate(colorChangeItemDetectorGameObject);
        colorChangeItemDetector = item.GetComponent<ColorChangeItemDetector>();
        colorChangeItemDetector.SetStepDistance(7f);
        colorChangeItemDetector.SetStartingPosition(this.transform.position);
        item.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    private ObstacleComponent SelectRandomComponent()
    {
        return obstacleComponentList[new System.Random().Next(0, obstacleComponentList.Length)];
    }

}

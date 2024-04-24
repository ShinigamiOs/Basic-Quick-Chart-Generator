using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/// <summary>
/// Example Class, not require, just for Test
/// Just to clarify, a Chart have one ChartStyle that define the type, colors and sizes
/// and can have multiple ChartDataset, this are the data in numbers of the graph, 
/// </summary>
public class ExampleChart : MonoBehaviour
{

    [Header("Chart Style")]
    [SerializeField] private ChartType chartType = ChartType.Line;
    [SerializeField] private Color colorCategoryLabels = Color.gray;
    [SerializeField] private float sizeCategoryLabels = 14f;
    [SerializeField] private bool displayfontX = true;
    [SerializeField] private Color colorfontX = Color.gray;
    [SerializeField] private float sizefontX = 14f;
    [SerializeField] private bool displayfonty = true;
    [SerializeField] private Color colorfontY = Color.gray;
    [SerializeField] private float sizefontY = 14f;
    [SerializeField] private int width = 400;
    [SerializeField] private int height = 300;

    [Header("Chart")]
    [SerializeField] private Color[] colorsBackgDataset;
    [SerializeField] private Color colorBorderDataset1 = Color.gray;
    [SerializeField] private Color colorBorderDataset2 = Color.gray;
    [SerializeField] private Color colorBorderDataset3 = Color.gray;

    [SerializeField] private bool fillDataset1 = false;
    [SerializeField] private bool fillDataset2 = false;
    [SerializeField] private bool fillDataset3 = false;

    [SerializeField] private UnityEvent <Texture2D> OnChartTextureReady;

   
    private void Start()
    {
        
    }
    public void CreateChart(){
        //Create a Chart for the amount of fruit that i have seen in my dreams in the week
        // Create ChartStyle whit editor Variables
        ChartStyle chartStyle = new ChartStyle(
            chartType,
            colorCategoryLabels,
            sizeCategoryLabels,
            colorfontX,
            sizefontX,
            colorfontY,
            sizefontY,
            displayfontX,
            displayfonty,
            width,
            height
        );

        //Category Labels
        string[] categoryLabels = new string[]{"Lunes","Martes","Miercoles","Jueves","Viernes"};

        // data for datasets
        float[] data1 = new float[] { 50f, 60f, 70f, 180f, 190f }; 
        float[] data2 = new float[] { 100f, 200f, 300f, 400f, 500f }; 
        float[] data3 = new float[] { 150f, 130f, 200f, 600f, 450f }; 
    

        //datasets for chart
        ChartDataset dataset1 = new ChartDataset("Sandias", data1, fillDataset1, colorBorderDataset1, colorsBackgDataset);
        ChartDataset dataset2 = new ChartDataset("Melones", data2, fillDataset2, colorBorderDataset2, colorsBackgDataset);
        ChartDataset dataset3 = new ChartDataset("Guayabas", data3, fillDataset3, colorBorderDataset3, colorsBackgDataset);

        // Create chart
        Chart chart = new Chart(categoryLabels, new ChartDataset[] { dataset1,dataset2 }, chartStyle);

        // Call function to generate image from url
        GetComponent<ChartGenerator>().GenerateChartImage(chart, ChartTextureReady);
    }

    /// <summary>
    /// It will be called when the texture is ready if there is no problem
    /// </summary>
    /// <param name="chartTexture">the texture if the chart to be applied in a Rawimage Maybe</param>
    private void ChartTextureReady(Texture2D chartTexture)
    {
        OnChartTextureReady?.Invoke(chartTexture);
    }
}

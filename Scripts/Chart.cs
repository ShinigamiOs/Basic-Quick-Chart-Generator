using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// Main class to create a graph
/// </summary>
/// <param name="CategoryLabelsX">labels in the X direction</param>
/// <param name="datasets">graph data sets, can be more than 1</param>
/// <param name="Style">Style chart</param>
/// <param name="version">QuickChart Version, usually no need to change</param>
public class Chart
{
    public string[] CategoryLabelsX { get; set; }
    public ChartDataset[] Datasets { get; set; }
    public ChartStyle Style { get; set; }
    private string version = "2.9.4";
    /// <summary>
    /// Constructor Class
    /// </summary>
    public Chart(string[] categoryLabelsX, ChartDataset[] datasets, ChartStyle style)
    {
        CategoryLabelsX = categoryLabelsX;
        Datasets = datasets;
        Style = style;
    }

    /// <summary>
    /// Create the url of the chart with the data
    /// </summary>
    /// <returns>string: url of the chart with the data </returns>
    public string ChartURL(){
        //essential general information
        string url = "https://quickchart.io/chart?";
        url += "v="+version;

        //Category Labels
        string typeFirstCharLower = Style.Type.ToString().Substring(0, 1).ToLower() + Style.Type.ToString().Substring(1);
        url += $"&c= {{ type: '{typeFirstCharLower}', data: {{ labels: ['{string.Join("', '", CategoryLabelsX)}'],";
        
        //dataset information
        url += "datasets: [";

        bool firstDataset = true; // Variable to control if it is the first dataset
        foreach (var dataset in Datasets){
            if (!firstDataset){
                url += ",";
            }
            else
            {
                firstDataset = false;
            }
            string stringBackgroundColor = "";
            if(Style.Type == ChartType.Line || Style.Type == ChartType.Radar){
                stringBackgroundColor = ColorToStringFormatRGBA(dataset.BackgroundColor[0]);
            }
            else{
                stringBackgroundColor = ColorsToStringFormatRGBA(dataset.BackgroundColor);
            }
            url += $"{{label: '{dataset.Label}', data: [{string.Join(", ", dataset.Data)}], fill: {dataset.Fill.ToString().ToLower()}, borderColor: {ColorToStringFormatRGBA(dataset.BorderColor)}, backgroundColor: {stringBackgroundColor}, }}";
        }
        url +="], },"; 

        //additional options
        url += "options: {scales: { xAxes: [{ display: "+Style.DisplayAxeX.ToString().ToLower()+", ticks: { fontColor: "+ColorToStringFormatRGBA(Style.FontXColor)+" } }],yAxes: [{ display: "+Style.DisplayAxeY.ToString().ToLower()+", ticks: { fontColor: "+ColorToStringFormatRGBA(Style.FontYColor)+" } }],},";
        //Legend options
        url += "legend: {labels: {fontSize: "+Style.CategoryLabelsFontSize+",fontColor: "+ColorToStringFormatRGBA(Style.CategoryLabelsFontColor) +"}}},";
        url += "}";
        Debug.Log(url);
        return url;
    
    }
    /// <summary>
    /// Convert an array or list of Color to String whit format ['rgba(0,0,0,0)','rgba(0,0,0,0)'] format
    /// </summary>
    /// <param name="colors">array or list to converte</param>
    /// <returns>string with all the colors in format </returns>
    private string ColorsToStringFormatRGBA(Color[] colors){
    List<string> colorStrings = new List<string>();

        foreach (Color color in colors)
        {
            
            colorStrings.Add(ColorToStringFormatRGBA(color));
        }

        return "[" + string.Join(", ", colorStrings) + "]";
    }
    /// <summary>
    /// Convert a Color to rgba with 'rgba(0,0,0,0)' format
    /// </summary>
    /// <param name="color">Color to convert</param>
    /// <returns>string with format rgba</returns>
    private string ColorToStringFormatRGBA(Color color){
        int r = Mathf.RoundToInt(color.r * 255);
        int g = Mathf.RoundToInt(color.g * 255);
        int b = Mathf.RoundToInt(color.b * 255);
        float a = color.a; 
        
        return $"'rgba({r}, {g}, {b}, {a})'";
    }
}
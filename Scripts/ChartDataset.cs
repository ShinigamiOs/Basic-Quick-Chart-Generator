using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Represents one dataset of a chart.
/// </summary>
/// <param name="Label">Name of the dataset.</param>
/// <param name="Data">Data of the dataset.</param>
/// <param name="Fill">use color fill from graph data set.</param>
/// <param name="BorderColor">Filled color border.</param>
/// <param name="BackgroundColor">arrays of Colors to fill from graph data set, Line and Radar only use the first color of the array.</param>
public class ChartDataset
{
    public string Label { get; set; }
    public float[] Data { get; set; }
    public bool Fill { get; set; }
    public Color BorderColor { get; set; }
    public Color[] BackgroundColor { get; set; }

    /// <summary>
    /// Construcctor class
    /// </summary>
    public ChartDataset(string label, float[] data, bool fill, Color borderColor, Color[] backgroundColor)
    {
        Label = label;
        Data = data;
        Fill = fill;
        BorderColor = borderColor;
        BackgroundColor = backgroundColor;
    }

}
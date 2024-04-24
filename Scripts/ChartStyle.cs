using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Style Chart
/// </summary>
/// <param name="type">Type chart</param>
/// <param name="categoryLabelsFontColor">Font Color of Category labels</param>
/// <param name="categoryLabelsFontSize">Font Size of Category labels</param>
/// <param name="fontXColor">Font color of X labels</param>
/// <param name="fontXSize">Font Size  of X labels</param>
/// <param name="fontYColor">Font Color of Y labels</param>
/// <param name="fontYSize">Font Size  of Y labels</param>
/// <param name="displayAxeX">Display grid and labels X</param>
/// <param name="displayAxeY">Display grid and labels Y</param>
/// <param name="width">Chart Width</param>
/// <param name="height">Chart Height</param>
public class ChartStyle{
    private ChartType type;
    private Color categoryLabelsFontColor;
    private float categoryLabelsFontSize;
    private Color fontXColor;
    private float fontXSize;
    private Color fontYColor;
    private float fontYSize;
    private bool displayAxeX;
    private bool displayAxeY;
    private int width;
    private int height;

    public ChartType Type { 
        get { return type; } 
        set { type = value; } 
    }
    public Color CategoryLabelsFontColor{
        get { return categoryLabelsFontColor; } 
        set { categoryLabelsFontColor = value; } 
    }
    public float CategoryLabelsFontSize{
        get { return categoryLabelsFontSize; } 
        set { categoryLabelsFontSize = value; } 
    }
    public int Width { 
        get { return width; } 
        set { width = value; } 
    }

    public int Height { 
        get { return height; } 
        set { height = value; } 
    }
    public Color FontXColor { 
        get { return fontXColor; } 
        set { fontXColor = value; } 
    }
    public float FontXSize{
        get { return fontXSize; } 
        set { fontXSize = value; }     
    }
    public Color FontYColor { 
        get { return fontYColor; } 
        set { fontYColor = value; } 
    }
    public float FontYSize{
        get { return fontYSize; } 
        set { fontYSize = value; }     
    }
    public bool DisplayAxeX{
        get { return displayAxeX; } 
        set { displayAxeX = value; } 
    }
    public bool DisplayAxeY{
        get { return displayAxeY; } 
        set { displayAxeY = value; } 
    }
    /// <summary>
    /// Constructor Class
    /// </summary>

    public ChartStyle(
        ChartType type,
        Color categoryLabelsFontColor,
        float categoryLabelsFontSize,
        Color fontXColor,
        float fontXSize,
        Color fontyColor,
        float fontYSize,
        bool displayAxeX,
        bool displayAxeY,
        int width,
        int height)
    {
        this.type = type;
        this.categoryLabelsFontColor = categoryLabelsFontColor;
        this.categoryLabelsFontSize = categoryLabelsFontSize;
        this.fontXColor = fontXColor;
        this.fontXSize = fontXSize;
        this.fontYColor = fontyColor;
        this.fontYSize = fontYSize;
        this.displayAxeX = displayAxeX;
        this.displayAxeY = displayAxeY;
        this.width = width;
        this.height = height;
    }
}
/// <summary>
/// Specifies the type of chart.
/// </summary>
public enum ChartType
{
    Bar,
    Line,
    Radar,
    Pie,
    Doughnut,
    PolarArea
}
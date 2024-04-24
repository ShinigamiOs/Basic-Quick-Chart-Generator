using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using System;

/// <summary>
/// Class that get the graph with the url from the internet.
/// </summary>
/// <param name="OnDownloadError">Event when there ir an error</param>
/// <param name="OnChartNull">Event when the chart is null</param>
/// <param name="OnChartGenerate">Event when the chart is generated</param>
public class ChartGenerator : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> OnDownloadError;
    [SerializeField] private UnityEvent OnChartNull;
    [SerializeField] private UnityEvent OnChartGenerate;

    /// <summary>
    /// Generate the chart, call the action when the texture is ready
    /// </summary>
    /// <param name="chart">chart from Chart class to get the texture</param>
    /// <param name="onTextureReady">Action that will send the texture</param>
    public void GenerateChartImage(Chart chart, Action<Texture2D> onTextureReady)
    {
        if (chart == null)
        {
            OnChartNull?.Invoke();
            return;
        }

        string chartURL = chart.ChartURL();
        StartCoroutine(DownloadChartImage(chartURL, onTextureReady));
    }

    /// <summary>
    /// Download the Chart from QuickChart.io in a courutine
    /// </summary>
    /// <param name="url">image url in quickchart.io</param>
    /// <param name="onTextureReady">Action to call when the texture is ready</param>
    /// <returns></returns>
    private IEnumerator DownloadChartImage(string url, Action<Texture2D> onTextureReady)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error downloading chart image: " + www.error);
            OnDownloadError?.Invoke(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            onTextureReady?.Invoke(texture);
            OnChartGenerate?.Invoke();
        }
    }
}
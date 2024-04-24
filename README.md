![Baner](https://github.com/ShinigamiOs/Basic-Quick-Chart-Generator/blob/main/images/Baner.png)
# Basic-Quick-Chart-Generator
Chart generator using quickchart.io with a url

Basic QuickChart.io URL Generator es una herramienta simple pero poderosa que te permite generar fácilmente URLs para crear gráficos personalizados utilizando QuickChart.io.

A diferencia de la instalación de la librería QuickChart.io, esta herramienta proporciona una solución rápida y sin complicaciones para crear URLs de gráficos simples sin la necesidad de instalar librerías externas. Con esta herramienta, puedes crear gráficos de barras, gráficos Lineares, gráficos de Radar, entre otros, simplemente proporcionando los datos y ajustando las opciones según tus necesidades. Ya sea que necesites visualizar datos estadísticos, mostrar tendencias o crear informes visuales, Basic QuickChart.io URL Generator te ofrece una manera rápida y eficiente de crear gráficos personalizados sin la necesidad de instalar otras dependencias. ¡Optimiza tu flujo de trabajo y agiliza la creación de gráficos con esta práctica herramienta!

## Contenido

1. Basic QuickChart.io URL Generator
2. Componentes
3. Instrucciones de Uso
4. Requisitos
5. Notas de la Versión
6. Licencia
7. Créditos
8. Contacto y soporte

## Componentes

La herramienta se compone de 4 scripts:

1. **ChartStyle**: Contiene información sobre el estilo de una gráfica, como colores, tamaño, visualización de los ejes.

   Atributos:
   - `private ChartType type;`
     - Bar
     - Line
     - Radar
     - Pie
     - Doughnut
     - PolarArea
   - `private Color categoryLabelsFontColor`
   - `private float categoryLabelsFontSize`
   - `private Color fontXColor`
   - `private float fontXSize`
   - `private Color fontYColor`
   - `private float fontYSize`
   - `private bool displayAxeX`
   - `private bool displayAxeY`
   - `private int width`
   - `private int height`

2. **CharDataset**: Contiene información del conjunto de datos de la gráfica como el nombre, los datos, y colores.

   Atributos:
   - `string Label`
   - `float[] Data`
   - `bool Fill`
   - `Color BorderColor`
   - `Color[] BackgroundColor`

3. **Chart**: Representa una Gráfica, necesita las etiquetas de categoría de la gráfica (las que suelen ir en el eje x) un Estilo de gráfica y al menos un Conjunto de datos, también contiene la versión pero esto raramente necesita ser modificado.

   Atributos:
   - `string[] CategoryLabelsX`
   - `ChartDataset[] Datasets`
   - `ChartStyle Style`
   - `string version`

   Funciones:
   - `string ChartURL()`: Convierte todos los datos de una gráfica en una string que representa una URL que permite obtener la gráfica.
   - `ColorsToStringFormatRGBA(Color[] colors)`: convierte un conjunto de colores en un string con el formato `['rgba(0,0,0,0)','rgba(0,0,0,0)']`
   - `ColorToStringFormatRGBA(Color color)`: convierte un color en un string con el formato `'rgba(0,0,0,0)'`

4. **ChartGenerator**: Se encarga de generar la imagen.

   Funciones:
   - `GenerateChartImage(Chart chart, Action<Texture2D> onTextureReady)`: Envia la informacion de la url a una co-rutina.
   - `IEnumerator DownloadChartImage(string url, Action<Texture2D> onTextureReady)`: co-rutina que se encarga de enviar la url y esperar la imagen, una vez la imagen ha sido descargada exitosamente ejecuta la función que haya sido pasada como parámetro.

## Instrucciones de Uso

1. Primero es necesario agregar ChartGenerator a nuestra escena.
   ![Imagen de la escena](https://github.com/ShinigamiOs/Basic-Quick-Chart-Generator/blob/main/images/Img%20Scene.png)
2. En el mismo GameObject Agregamos nuestro script donde crearemos nuestra grafica y la instanciaremos con su información.
   ![Instanciar Chart](https://github.com/ShinigamiOs/Basic-Quick-Chart-Generator/blob/main/images/Img%20InstantiateChart.png)
3. Después llamaremos a la función que se encuentra en ChartGenerator GenerateChartImage pasando como parámetros la gráfica y una función que reciba un Texture2D como parámetro, que se ejecutará cuando la imagen este lista.
    ![Llamar Funcion](https://github.com/ShinigamiOs/Basic-Quick-Chart-Generator/blob/main/images/Img%20CallFunction.png)
   ![Funcion de ejemplo](https://github.com/ShinigamiOs/Basic-Quick-Chart-Generator/blob/main/images/Img%20Function.png)
## Requisitos

- Tener los 4 Scripts en el proyecto.

## Notas de la Versión

Versión 1.0: Permite crear algunas graficas como: Barras, Línea, Radar, Pie, Dona, Área polar.

## Licencia

GNU: Esta herramienta, así como cualquier modificación debe ser libre de uso para el público, puede ser usada en productos de carácter comercial siempre y cuando este no sea parte integral o comprenda la mayor parte del proyecto.

## Créditos

- QuickChart.io
- Programador: Gustavo Adolfo Hernandez Elizondo.

## Contacto y soporte

Correo: tavo98a@gmail.com

## Biblioteca de processamento de imagens para C#

### Recursos

- Gamma
- Brilho
- Contraste
- Inverter cores
- Filtro de cores

### Dependencias

- [ImageSharp](https://github.com/SixLabors/ImageSharp)

### Exemplos

- Carregando a imagem:
````c#
Image<Argb32> img = Image.Load<Argb32>("ceira.png");
await img.SaveAsync("images/ceira.png", new PngEncoder());
````
<img src="images/ceira.png" />

- Aplicando gamma em **2.5** 
````c#
Image<Argb32> ceirain = img.Clone();

Processor.Gamma(ref ceirain, 2.5f);
await ceirain.SaveAsync("images/ceiragamma.png", new PngEncoder());
````

<img src="images/ceiragamma.png" />

- Aplicando brilho em **50**
````c#
ceirain = img.Clone();

Processor.Brightness(ref ceirain, 50);
await ceirain.SaveAsync("images/ceirabrightness.png", new PngEncoder());
````

<img src="images/ceirabrightness.png" />

- Aplicando contraste em **70**
````c#
ceirain = img.Clone();

Processor.Contrast(ref ceirain, 70);
await ceirain.SaveAsync("images/ceiracontrast.png", new PngEncoder());
````

<img src="images/ceiracontrast.png" />

- Invertendo as cores
````c#
ceirain = img.Clone();

Processor.InvertColor(ref ceirain);
await ceirain.SaveAsync("images/ceirainvert.png", new PngEncoder());
````

<img src="images/ceirainvert.png" />

- Filtrando uma cor
````c#
ceirain = img.Clone();

Processor.ColorFilter(ref ceirain, new Argb32(255, 0, 0));
await ceirain.SaveAsync("images/ceirafilter.png", new PngEncoder());
````

<img src="images/ceirafilter.png" />
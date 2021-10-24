using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using WaxImage;

Image<Argb32> img = Image.Load<Argb32>("ceira.png");
await img.SaveAsync("images/ceira.png", new PngEncoder());

Image<Argb32> ceirain = img.Clone();

Processor.Gamma(ref ceirain, 2.5f);
await ceirain.SaveAsync("images/ceiragamma.png", new PngEncoder());

ceirain = img.Clone();

Processor.Brightness(ref ceirain, 50);
await ceirain.SaveAsync("images/ceirabrightness.png", new PngEncoder());

ceirain = img.Clone();

Processor.Contrast(ref ceirain, 70);
await ceirain.SaveAsync("images/ceiracontrast.png", new PngEncoder());

ceirain = img.Clone();

Processor.InvertColor(ref ceirain);
await ceirain.SaveAsync("images/ceirainvert.png", new PngEncoder());

ceirain = img.Clone();

Processor.ColorFilter(ref ceirain, new Argb32(255, 0, 0));
await ceirain.SaveAsync("images/ceirafilter.png", new PngEncoder());
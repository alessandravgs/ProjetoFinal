using SkiaSharp;

namespace ProjetoFinal.Helpers
{
    public static class ImageHelper
    {
        private static byte[] CompressImage(byte[] imageBytes, long quality)
        {
            using (var inputStream = new MemoryStream(imageBytes))
            {
                using (var originalBitmap = SKBitmap.Decode(inputStream))
                {
                    using (var compressedStream = new MemoryStream())
                    {
                        var image = SKImage.FromBitmap(originalBitmap);
                        var data = image.Encode(SKEncodedImageFormat.Jpeg, (int)quality);
                        data.SaveTo(compressedStream);
                        return compressedStream.ToArray();
                    }
                }
            }
        }

        private static byte[] ResizeImage(byte[] imageBytes, int width, int height)
        {
            using (var inputStream = new MemoryStream(imageBytes))
            {
                using (var originalBitmap = SKBitmap.Decode(inputStream))
                {
                    using (var resizedBitmap = originalBitmap.Resize(new SKSizeI(width, height), SKFilterQuality.High))
                    {
                        using (var resizedStream = new MemoryStream())
                        {
                            var image = SKImage.FromBitmap(resizedBitmap);
                            var data = image.Encode(SKEncodedImageFormat.Jpeg, 100); // 100 for maximum quality
                            data.SaveTo(resizedStream);
                            return resizedStream.ToArray();
                        }
                    }
                }
            }
        }

        private static string ConvertToBase64(byte[] imageBytes)
        {
            return Convert.ToBase64String(imageBytes);
        }

        public static string ProcessImage(byte[] originalImageBytes, long quality, int width, int height)
        {
            var resizedImage = ResizeImage(originalImageBytes, width, height);
            var compressedImage = CompressImage(resizedImage, quality);
            return ConvertToBase64(compressedImage);
        }
    }
}

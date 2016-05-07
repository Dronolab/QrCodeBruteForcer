using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace qrcode
{
    public class QrCodeWorker
    {
        public enum caseType { White, Black, Unknown }
        private string tempDirectory = "temp";
        private int imageSize;
        

        private string DecodeQRcode(Bitmap image)
        {
            //imageString = base64 string of image
            ImageConverter converter = new ImageConverter();
            var bitmapData = (byte[])converter.ConvertTo(image, typeof(byte[]));
            var streamBitmap = new System.IO.MemoryStream(bitmapData);
            var bitmap = new System.Drawing.Bitmap((System.Drawing.Bitmap)System.Drawing.Image.FromStream(streamBitmap));

            //test1
            var luminanceSource1 = new ZXing.BitmapLuminanceSource(bitmap);
            var binarizer1 = new ZXing.Common.HybridBinarizer(luminanceSource1);
            var mapa1 = new ZXing.BinaryBitmap(binarizer1);
            var readCode1 = new ZXing.QrCode.QRCodeReader();
            var result1 = readCode1.decode(mapa1);

            //test2
            var options2 = new ZXing.Common.DecodingOptions();
            options2.TryHarder = true;
            var formats2 = new List<ZXing.BarcodeFormat>();
            formats2.Add(ZXing.BarcodeFormat.QR_CODE);
            options2.PossibleFormats = formats2;
            var reader2 = new ZXing.BarcodeReader(null, null, ls => new ZXing.Common.GlobalHistogramBinarizer(ls)) { AutoRotate = true, TryInverted = true, Options = options2 };
            var result2 = reader2.Decode(bitmap);

            if(result2 != null)
                return result2.Text;

            if (result1 != null)
                return result1.Text;

            return "";
        }

        public QrCodeWorker(int imgSize)
        {
            imageSize = imgSize;
        }

        public List<Tuple<string, caseType[,]>> ProcessQRcode(caseType[,] qrArray)
        {
            var results = new List<Tuple<string, caseType[,]>>();
            List<Point> UnidentifiedSlots = new List<Point>();
            ////temp directory
            //try {
            //    if (!Directory.Exists(tempDirectory))
            //        Directory.CreateDirectory(tempDirectory);
            //}
            //catch(Exception){ }

            ////Source QR code
            //Bitmap sourceImage = CreateQRcode(qrArray);
            //try {
            //    sourceImage.Save(tempDirectory + "/source.jpg");
            //}
            //catch (Exception) { }

            //Get the unidentified cases
            for (int line = 0; line < qrArray.GetLength(0); line++)
            {
                for (int col = 0; col < qrArray.GetLength(1); col++)
                {
                    if (qrArray[line, col] == caseType.Unknown)
                        UnidentifiedSlots.Add(new Point(line, col));
                }
            }

            for (Int64 i = 0; i < Math.Pow(2, UnidentifiedSlots.Count); i++)
            {
                string binVals = Convert.ToString(i, 2).PadLeft(UnidentifiedSlots.Count, '0');
                caseType[,] UpdatedArray = new caseType[qrArray.GetLength(0), qrArray.GetLength(1)];
                int binIterator = 0;
                for (int line = 0; line < qrArray.GetLength(0); line++)
                {
                    for (int col = 0; col < qrArray.GetLength(1); col++)
                    {
                        if (qrArray[line, col] == caseType.Unknown)
                        {
                            if(binVals[binIterator] == '0')
                                UpdatedArray[line, col] = caseType.Black;
                            else
                                UpdatedArray[line, col] = caseType.White;
                            //Console.WriteLine(UpdatedArray[line, col]);
                            binIterator++;
                        }
                        else
                            UpdatedArray[line, col] = qrArray[line, col];
                    }
                }

                Bitmap qrCode = CreateQRcode(UpdatedArray);
                //qrCode.Save(tempDirectory + "\\" + binVals + ".jpg");

                try {
                    var decodedQrCode = DecodeQRcode(qrCode);
                    results.Add(new Tuple<string, caseType[,]>(decodedQrCode, UpdatedArray));
                }catch(Exception){}

            }
            return results;
        }

        

        private Bitmap CreateQRcode(caseType[,] qrArray)
        {
            Bitmap baseQR = new Bitmap(imageSize, imageSize);
            using (Graphics g = Graphics.FromImage(baseQR))
            {
                var whitePen = new System.Drawing.Pen(System.Drawing.Color.White, 1);
                var grayPen = new System.Drawing.Pen(System.Drawing.Color.Gray, 1);
                var BlackPen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);


                for (int line = 0; line < qrArray.GetLength(0); line++)
                {
                    for (int col = 0; col < qrArray.GetLength(1); col++)
                    {
                        QrCodeWorker.caseType val = qrArray[line, col];
                        Size s = new Size((baseQR.Size.Height + 1) / qrArray.GetLength(0), (baseQR.Size.Width + 1) / qrArray.GetLength(1));
                        Point loc = new Point(line * s.Height, col * s.Width);
                        switch (val)
                        {
                            case QrCodeWorker.caseType.Black:
                                g.FillRectangle(new SolidBrush(System.Drawing.Color.Black), new Rectangle(loc, s));
                                break;
                            case QrCodeWorker.caseType.White:

                                g.FillRectangle(new SolidBrush(System.Drawing.Color.White), new Rectangle(loc, s));
                                break;
                            case QrCodeWorker.caseType.Unknown:

                                g.FillRectangle(new SolidBrush(System.Drawing.Color.Gray), new Rectangle(loc, s));
                                break;
                        }
                    }
                }
            }

            return baseQR;
        }
    }

    
}

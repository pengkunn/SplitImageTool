﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SplitImage.Core
{
    public class SplitImageClass
    {
        static public void SplitImageDiretory(string diretoryName, int rowCount, int colCount)
        {
            foreach (string fileName in Directory.GetFiles(diretoryName))
            {
                SplitImageFile(fileName, rowCount, colCount);
            }
             
        }

        /// <summary>
        /// 将图像按指定的行和列进行切割，切割的图片存储到原图片目录的同名文件夹下
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        static public void SplitImageFile(string fileName, int rowCount, int colCount)
        {
            Image image = Image.FromFile(fileName);

            string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
            string fileExtension = System.IO.Path.GetExtension(fileName);
            string fileDirectory = System.IO.Path.GetDirectoryName(fileName);

            int colWidth = image.Width / colCount;
            int rowHeight = image.Height / rowCount;

            int i = 0;
            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                {
                    Bitmap newBmp = new Bitmap(colWidth, rowHeight, PixelFormat.Format24bppRgb);
                    newBmp.MakeTransparent();
                    Graphics newBmpGraphics = Graphics.FromImage(newBmp);
                    newBmpGraphics.Clear(Color.Transparent);
                    newBmpGraphics.DrawImage(image, new Rectangle(0, 0, colWidth, rowHeight),
                        new Rectangle(col * colWidth, row * rowHeight, colWidth, rowHeight), GraphicsUnit.Pixel);
                    newBmpGraphics.Save();
                    string newDirectory = fileDirectory + "\\" + fileNameWithoutExtension;
                    if (!Directory.Exists(newDirectory))
                    {
                        Directory.CreateDirectory(newDirectory);
                    }
                    string newfileName = newDirectory + "\\" + fileNameWithoutExtension + "_" + i.ToString() + fileExtension;
                    newBmp.Save(newfileName,ImageFormat.Png);

                    i++;
                }
            }



        }
    }
}

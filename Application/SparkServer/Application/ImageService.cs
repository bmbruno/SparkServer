﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using SparkServer.Models;

namespace SparkServer.Application
{
    /// <summary>
    /// Provides methods for loading, resizing, creating thumbnails, and other image tasks.
    /// </summary>
    public class ImageService
    {
        private string _folderPath = string.Empty;
        private string _mappedFolderPath = string.Empty;
        private const string _noThumbnailPath = "/Content/Images/nothumbnail.png";

        public ImageService(string folderPath, string mappedFolderPath)
        {
            _folderPath = folderPath;
            _mappedFolderPath = mappedFolderPath;
        }

        public List<ImageListItem> GetBannerListFromDisk()
        {
            List<ImageListItem> imageList = new List<ImageListItem>();

            if (!Directory.Exists(_mappedFolderPath))
                throw new DirectoryNotFoundException($"No banner directory found at {_mappedFolderPath}");

            foreach (string filePath in Directory.GetFiles(_mappedFolderPath))
            {
                if (filePath.Contains("_thumb"))
                    continue;

                FileInfo info = new FileInfo(filePath);
                string thumbnailMappedPath = $"{info.DirectoryName}\\{Path.GetFileNameWithoutExtension(filePath)}_thumb.jpg";
                string thumbnailURL = $"{_folderPath.Replace("~", string.Empty)}/{Path.GetFileNameWithoutExtension(filePath)}_thumb.jpg";

                ImageListItem imageItem = new ImageListItem();
                imageItem.Filename = info.Name;
                imageItem.Filepath = $"{_folderPath.Replace("~", string.Empty)}/{info.Name}";
                imageItem.ThumbnailPath = (File.Exists(thumbnailMappedPath)) ? thumbnailURL : _noThumbnailPath;

                imageList.Add(imageItem);
            }

            return imageList;
        }

        public bool FileExistsByName(string filename)
        {
            return File.Exists($"{_mappedFolderPath}{filename}");
        }

        public void CreateThumbnail(string newFileMappedPath)
        {
            Image image = Image.FromFile(newFileMappedPath);
            Size size = new Size() { Width = 360, Height = 180 };

            Image thumbnailImage = ResizeImage(image, size, true);

            string thumbnailFilepath = GetBannerThumbnailPath(Path.GetFileNameWithoutExtension(newFileMappedPath), true);

            thumbnailImage.Save(thumbnailFilepath);

            thumbnailImage.Dispose();
            image.Dispose();
        }

        private Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;

            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }

            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.Bicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private string GetBannerThumbnailPath(string filename, bool mapped)
        {
            filename = filename.Replace(".jpg", string.Empty);

            if (mapped)
                return $"{_mappedFolderPath}\\{filename}_thumb.jpg";
            else
                return $"{_folderPath}\\{filename}_thumb.jpg";
        }

        public void DeleteBanner(string filename)
        {
            string filepath = $"{_mappedFolderPath}\\{filename}";
            string thumbnailPath = GetBannerThumbnailPath(filename, true);

            if (File.Exists(filepath))
                File.Delete(filepath);

            if (File.Exists(thumbnailPath))
                File.Delete(thumbnailPath);
        }
    }
}
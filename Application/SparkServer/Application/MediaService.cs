using System;
using System.Collections.Generic;
using System.IO;
using SparkServer.Models;

namespace SparkServer.Application
{
    public class MediaService
    {
        private string _folderPath = string.Empty;
        private string _mappedFolderPath = string.Empty;
        private const string _noThumbnailPath = "/Content/Images/nothumbnail.png";

        public MediaService(string folderPath, string mappedFolderPath)
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
    }
}
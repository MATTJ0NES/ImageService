using ImageService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ImageService.Helpers
{
    public static class UrlHelpers
    {

		/// <summary>
		/// Get the file path for the file, including the directory.
		/// </summary>
		/// <param name="separator">Seperator between folders.</param>
		/// <returns>File path.</returns>
		public static string GetFileStoragePath(int fileId, string fileName, char separator)
		{
			return GetFileStoreDirectory(fileId, separator) + fileName;
		}

		private static string GetFileStoreDirectory(int fileId, char separator)
		{
			double parentDir = (Math.Floor(((double)fileId) / 10000)) * 10;
			int childDir = (int)(Math.Floor((fileId - (parentDir * 1000)) / 1000));
			return String.Concat(parentDir.ToString(), separator, childDir, separator);
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAMPPSiteManager
{
	public class FileUtil
	{
		public static void DeleteBytes(string filePath, int offset, int length)
		{
			using (FileStream fileReadStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Write))
			{
				using (FileStream fileWriteStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read))
				{
					fileWriteStream.Seek(offset, SeekOrigin.Begin);
					fileReadStream.Seek(offset + length, SeekOrigin.Begin);

					for (int i = offset + length; i < fileReadStream.Length; i++)
					{
						fileWriteStream.WriteByte((byte)fileReadStream.ReadByte());
					}

					fileWriteStream.SetLength(fileReadStream.Length - length);
				}
			}
		}

		public static void InserBytes(string filePath, int offset, byte[] data)
		{
			byte[] cachedData;

			using (FileStream fileReadStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Write))
			{
				cachedData = new byte[fileReadStream.Length - offset];
				fileReadStream.Seek(offset, SeekOrigin.Begin);
				fileReadStream.Read(cachedData, 0, cachedData.Length);
			}

			using (FileStream fileWriteStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read))
			{
				int totalBytes = (int)(fileWriteStream.Length + data.Length);
				fileWriteStream.SetLength(totalBytes);
				fileWriteStream.Seek(offset, SeekOrigin.Begin);
				fileWriteStream.Write(data, 0, data.Length);
				fileWriteStream.Write(cachedData, 0, cachedData.Length);
			}
		}

		public static void AppendBytes(string filePath, byte[] data)
		{
			InserBytes(filePath, (int)new FileInfo(filePath).Length, data);
		}

		public static string ReadText(string filePath, Encoding encoding)
		{
			using (FileStream fileWriteStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				byte[] bytes = new byte[fileWriteStream.Length];
				fileWriteStream.Read(bytes, 0, bytes.Length);
				return encoding.GetString(bytes);
			}
		}

		public static void WriteText(string filePath, string contents, Encoding encoding)
		{
			byte[] bytes = encoding.GetBytes(contents);

			using (FileStream fileWriteStream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read))
			{
				fileWriteStream.Write(bytes,0,bytes.Length);
				fileWriteStream.SetLength(bytes.Length);
			}
		}
	}
}

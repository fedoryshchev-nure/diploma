using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Diploma.Common.DTOs
{
	/// <summary>
	/// Used to send Name of the file to the client back within same property file arrives
	/// </summary>
	public class FileDto : IFormFile
	{
		public string Name { get; set; }

		public FileDto(string name)
		{
			Name = name;
		}

		#region Not implemented

		public string ContentType => throw new NotImplementedException();

		public string ContentDisposition => throw new NotImplementedException();

		public IHeaderDictionary Headers => throw new NotImplementedException();

		public long Length => throw new NotImplementedException();

		public string FileName => throw new NotImplementedException();

		public void CopyTo(Stream target)
		{
			throw new NotImplementedException();
		}

		public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
		{
			throw new NotImplementedException();
		}

		public Stream OpenReadStream()
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}

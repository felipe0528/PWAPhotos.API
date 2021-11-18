using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWAPhotos.Models
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Filepath { get; set; }

        public byte[] Data { get; set; }

    }
}

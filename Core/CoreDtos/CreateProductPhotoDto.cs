using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreateProductPhotoDto
    {
        string Url { get; set; }

        bool IsMain { get; set; }
    }
}
using System.Text.Json;
using Core.Helpers;
using Microsoft.AspNetCore.Http; 

namespace Core.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            response.Headers.Append("Pagination", JsonSerializer.Serialize(header, jsonOptions)); // le puse append en vez de Add

            response.Headers.Append("Access-Control-Expose-Headers", "Pagination"); // le puse append en vez de Add
            

        }
    }
}
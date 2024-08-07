﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto
{
    public record PagedResponseDto<T>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages { get; init; }
        public List<T> Data { get; init; }

        public PagedResponseDto(List<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling((decimal)totalRecords / (decimal)pageSize);
        }
    }

    public static class PagesResponseDtoExtension
    {
        public static PagedResponseDto<T> ToPagedResponse<T>(this IEnumerable<T> fullData, int pageNumber, int pageSize)
        {
            var filtered = fullData.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponseDto<T>(filtered, pageNumber, pageSize, fullData.Count());
        }
    }
}

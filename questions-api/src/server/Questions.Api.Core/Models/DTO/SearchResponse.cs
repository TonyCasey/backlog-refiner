using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Api.Core.Models.DTO
{
    public class SearchResponse
    {
        public List<QuestionResponse> Data { get; set; }
    }
}

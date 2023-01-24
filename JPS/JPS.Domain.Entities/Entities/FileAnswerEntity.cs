using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace JPS.Domain.Entities.Entities
{
    public class FileAnswerEntity
    {
        public int AnswerId { get; set; }
        public string FileUrl { get; set; }
        public AnswerEntity Answer { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace SchoolManager.WebUI.Models
{
    public class ErrorModel
    {
        public string[]? Errors { get; set; }
        public ValidationError[]? ValidationErrors { get; set; }
    }

    public class ValidationError 
    {
        public string? Identifier { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ErrorCode { get; set; }
        public int Severity { get; set; }
    }
}

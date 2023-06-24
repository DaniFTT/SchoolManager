using SchoolManager.Domain.Entities;

namespace SchoolManager.WebAPI.Models.Shared
{
    public static class Routes
    {
        private const string BaseUri = "api";

        public const string StudentUri = $"{BaseUri}/student";
        public const string SchoolClassUri = $"{BaseUri}/schoolclass";
        public const string StudentSchoolClassUri = $"{BaseUri}/studentschoolclass";
    }
}

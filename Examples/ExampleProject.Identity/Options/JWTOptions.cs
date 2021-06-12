namespace ExampleProject.Identity.Options
{
    public class JWTOptions
    {
        public const string JWTSettings = "JWTSettings";

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}

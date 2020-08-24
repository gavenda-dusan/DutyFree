namespace DutyFree.Core.Entities.Users
{
    public class GoogleUserAccessTokenData
    {
        public string Iss { get; set; }
        public string Sub { get; set; }
        public string Azp { get; set; }
        public string Aud { get; set; }
        public string Iat { get; set; }
        public string Exp { get; set; }
        public string Hd { get; set; }
        public string Email { get; set; }
        public string Email_Verified { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Given_Name { get; set; }
        public string Family_Name { get; set; }
        public string Locale { get; set; }
    }
}
namespace AdaptTablet.ErgastAPI.Model.Driver
{
    public class Driver
    {
        public string DriverId { get; set; }
        public string Url { get; set; }
        public string CompleteName { get { return string.Format("{0} {1}", GivenName, FamilyName); } }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}

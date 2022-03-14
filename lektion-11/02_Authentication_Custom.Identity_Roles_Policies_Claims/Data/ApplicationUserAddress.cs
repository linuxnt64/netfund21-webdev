namespace _02_Authentication_Custom.Identity_Roles_Policies_Claims.Data
{
    public class ApplicationUserAddress
    {
        public string UserId { get; set; }
        public string AddressId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationAddress Address { get; set; }
    }
}

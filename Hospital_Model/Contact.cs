namespace Hospital_Model
{
    public class Contact
    {
        public int ID { get; set; }
        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
    }
}
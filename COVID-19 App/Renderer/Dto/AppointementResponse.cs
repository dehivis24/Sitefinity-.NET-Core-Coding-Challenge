using System;

namespace Renderer.Dto
{
    public class AppointementResponse
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime AppointmentDate { get; set; }

        public DateTime AppointmentTime { get; set; }

        public string AppointmentDetails { get; set; }
        public string Site { get; set; }

        public string UrlName { get; set; }       
    }
}

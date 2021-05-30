using System;
using System.ComponentModel.DataAnnotations;

namespace Renderer.ViewModels.VaccinationAppointment
{
    public class AppointmentViewModel : AppointmentDataViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id is required")]
        [MaxLength(20, ErrorMessage = "The field Id must be a string with a maximum length of 20")]
        public string Identifier { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The First Name is required")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime AppointmentTime { get; set; }

        public string AppointmentDetails { get; set; }

    }

}

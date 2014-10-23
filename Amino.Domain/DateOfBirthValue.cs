using System;

namespace Amino.Domain
{
    public class DateOfBirthValue
    {
        public DateOfBirthValue(DateTime dateOfBirth)
        {
            Date = dateOfBirth;
        }

        public DateTime Date 
        { 
            get;
            private set;
        }

        public int GetAge()
        {
            DateTime now = DateTime.Today;
            var age = now.Year - Date.Year;

            if (now < Date.AddYears(age))
            {
                age--;
            }

            return age;
        }

        public static implicit operator DateTime(DateOfBirthValue dateOfBirthValue)
        {
            return dateOfBirthValue.Date;
        }

        public static implicit operator string(DateOfBirthValue dateOfBirthValue)
        {
            return string.Format("{0} - {1}", dateOfBirthValue.ToString(), dateOfBirthValue.GetAge());
        }
    }
}

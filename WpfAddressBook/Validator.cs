using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WpfAddressBook
{
	public static class Validator
	{
		static Regex ValidEmailRegex = CreateValidEmailRegex();

		private static Regex CreateValidEmailRegex()
		{
			string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
				+ @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
				+ @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

			return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
		}

		// Check if email address is valid
		internal static bool IsEmailValid(string emailAddress)
		{
			bool isValid = ValidEmailRegex.IsMatch(emailAddress);

			return isValid;
		}

		// Check if phone number is valid
		internal static bool IsPhoneNumber(string number)
		{
			bool isValid = Regex.Match(number, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$").Success;
			return isValid;
		}
	}
}

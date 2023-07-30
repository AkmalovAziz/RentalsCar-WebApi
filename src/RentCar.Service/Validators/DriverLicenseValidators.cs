namespace RentCar.Service.Validators;

public class DriverLicenseValidators
{
    public static bool IsValid(string driverlicense)
    {
        if (driverlicense.Length != 8) return false;

        for (int i = 0; i < 2; i++)
        {
            if (char.IsUpper(driverlicense[i])) continue;
            else return false;
        }

        for (int i = 2; i < driverlicense.Length; i++)
        {
            if (char.IsDigit(driverlicense[i])) continue;
            else return false;
        }

        return true;
    }
}

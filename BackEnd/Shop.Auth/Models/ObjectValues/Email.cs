using System.Text.RegularExpressions;

namespace Shop.Auth.Models.ObjectValues;

public class Email
{
    public Email(string address)
    {
        ValidateAddress(address);
        Address = address;
    }
    
    public string Address { get;private set; }

    public void SetAddress(string address)
    {
        ValidateAddress(address);
        Address = address;
    }
    
    private void ValidateAddress(string address)
    {
        if(string.IsNullOrWhiteSpace(address))
            throw new Exception("Email with address invalid");

        var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        bool valid = regex.IsMatch(address);
        if (address.Length < 3 || address.Contains('@') || !valid)
            throw new Exception("Email with address invalid");
    }
    
}
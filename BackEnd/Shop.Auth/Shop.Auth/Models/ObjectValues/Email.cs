using System.Text.RegularExpressions;

namespace Shop.Auth.Models.ObjectValues;

public class Email
{
    public Email(){}
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
        
        if (address.Length < 3 || !address.Contains('@') )
            throw new Exception("Email with address invalid");
    }
    
}
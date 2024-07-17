namespace AspnetCoreMvcFull.Models;

public class AuthViewModel
{
  public class Login()
  {
    public string Email { get; set; }
    public string PassWord { get; set; }
  }

  public class Register()
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PassWord { get; set; }
  }
}

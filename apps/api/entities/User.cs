namespace calcalc.api.entities;

public class User {

	public int Id {get;  set;}
	
	public string Email {get; set;} = "";

	public string PasswordHash {get; set;} = "";

	public bool IsActive {get; set;}

	public bool IsVerified {get; set;} 

	public DateTimeOffset CreatedAt {get; set;} = DateTimeOffset.UtcNow;

	public DateTimeOffset UpdatedAt {get; set;} 
};

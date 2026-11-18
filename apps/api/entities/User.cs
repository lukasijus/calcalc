namespace calcalc.api.entities;

public class User {

	public int Id {get;  set;}
	
	public string Name {get; set;} = "";

	public DateTimeOffset CreatedAt {get; set;} = DateTimeOffset.UtcNow;
};

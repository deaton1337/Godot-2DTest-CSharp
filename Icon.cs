using Godot;

public partial class Icon : CharacterBody2D
{
	[Export] private CharacterBody2D thisNode;

	private int speed = 35000;
	private Vector2 direction;
	private Vector2 velocity;
	
	private Vector2 lowerBound = new Vector2(0, 0);
	private Vector2 upperBound = new Vector2(1920, 1080); 
	private float myRotation = 0.0f;

    public override void _Ready()
    {
		RandomNumberGenerator random = new RandomNumberGenerator();
		direction = new Vector2(random.RandfRange(-0.9f,1.0f), random.RandfRange(-0.9f,1.0f));
    }	
	

    public override void _PhysicsProcess(double delta)
	{
		Velocity = direction * speed * (float)delta;
		MoveAndSlide();

		if (IsOutOfBounds(thisNode.Position))
        {
            direction = -direction;
        }
		
		myRotation += 50 * (float)delta;
		thisNode.RotationDegrees = myRotation;
	}


    private bool IsOutOfBounds(Vector2 position)
    {
        return position.X <= lowerBound.X || position.Y <= lowerBound.Y ||
               position.X >= upperBound.X|| position.Y >= upperBound.Y;
    }

}

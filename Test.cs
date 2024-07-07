
using Godot;

public partial class Test : Node2D
{
	[Export] Label myLabel;
	[Export] Timer myTimer;

	private bool maxFPS = false;
	private int instanceCount = 0;
	private RandomNumberGenerator random;
	public PackedScene iconScene;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		random = new RandomNumberGenerator();
		iconScene = GD.Load<PackedScene>("res://Icon.tscn");
		for (int i = 0; i < 1500; i++)
		{
			instanceIcon();
		}
		myTimer.Timeout += HandleTimerTimeout;
	}

    private void HandleTimerTimeout()
    {
        myTimer.Timeout -= HandleTimerTimeout;
		maxFPS = false;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		addIcon();
	}

    private void addIcon()
    {

		var fps = Engine.GetFramesPerSecond();

		if (fps < 30)
		{		
			maxFPS = true;
		}

		if (!maxFPS)
		{
			instanceIcon();
		}

		myLabel.Text = "Count = " + instanceCount;
		myLabel.Text += "\nFPS = " +  fps;		
    }

	private void instanceIcon()
	{
			CharacterBody2D iconInstance = iconScene.Instantiate() as CharacterBody2D;
			iconInstance.Position = new Vector2(random.RandiRange(10,1900), random.RandiRange(10,1000));
			AddChild(iconInstance);
			instanceCount +=1 ;
	}
}

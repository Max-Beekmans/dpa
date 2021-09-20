using Builder;
using Model;
using State;

public class AstroidBuilder : BaseBodyBuilder
{
    public AstroidBuilder()
    {
        Current = new Astroid();
        Current.Type = typeof(Astroid);
    }

    public override ICelestialBodyBuilder AddStateContext(StateContext context)
    {
        ((Astroid) Current).StateContext = context;

        return this;
    }

    public override ICelestialBodyBuilder SetName(string name)
    {
        return this;
    }

    public override ICelestialBodyBuilder SetColor(string color)
    {
        return base.SetColor("Black");
    }

    public override ICelestialBodyBuilder SetRadius(int radius)
    {
        return base.SetRadius(5);
    }
}

using Builder;
using Model;
using State;

public class AstroidBuilder : BaseBodyBuilder
{
    public AstroidBuilder()
    {
        this.Current = new Astroid();
        this.Current.SubType = typeof(Astroid);
        this.SetColor("Black");
        this.SetRadius(5);
    }

    public override ICelestialBodyBuilder AddStateContext(StateContext context)
    {
        ((Astroid) Current).StateContext = context;

        return this;
    }
}

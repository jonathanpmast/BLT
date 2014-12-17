namespace BLT.WWW
{
    using Nancy;
    public class LootWheelModule : NancyModule
    {
        public LootWheelModule() {
            Get["sk"] = _ =>
            {
                
                return View["sk/index.cshtml"];
            };
        }
    }
}
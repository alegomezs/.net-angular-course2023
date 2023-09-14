using EFApp.Data;

namespace EFApp.Logic
{
    public class BaseLogic
    {
        protected readonly NorthwindContext context;

        public BaseLogic()
        {
            context = new NorthwindContext();
        }

        public BaseLogic(NorthwindContext context)
        {
            this.context = context;
        }
    }
}

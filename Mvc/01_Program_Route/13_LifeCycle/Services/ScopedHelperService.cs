namespace _13_LifeCycle.Services
{
    public class ScopedHelperService
    {
        private readonly ScopedRandomNumberService _scopedService;
        public ScopedHelperService(ScopedRandomNumberService scopedService)
        {
            _scopedService = scopedService;
        }
        public int GetScopedNumber()
        {
            return _scopedService.GetRandomNumber();
        }
    }
}

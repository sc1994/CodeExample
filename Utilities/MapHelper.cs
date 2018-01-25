using Nelibur.ObjectMapper;

namespace Utilities
{
    public static class MapHelper
    {
        public static TToEntity MapTo<TFromEntity, TToEntity>(this TFromEntity that) where TFromEntity : class 
                                                                                     where TToEntity : class
        {
            return TinyMapper.Map<TToEntity>(that);
        }
    }
}

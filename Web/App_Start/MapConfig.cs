using Nelibur.ObjectMapper;

namespace Web
{
    public class MapConfig
    {
        public static void Init()
        {
            PersonMapToPersonDto();
        }


        #region 配置了Map 的规则,具体规则参考: https://github.com/TinyMapper/TinyMapper
        private static void PersonMapToPersonDto()
        {
			// todo 示例
            //TinyMapper.Bind<Person, PersonDto>(config =>
            //{
            //    config.Ignore(x => x.Id);
            //    config.Ignore(x => x.Email);
            //    config.Bind(source => source.LastName, target => target.Surname);
            //});
        } 
        #endregion
    }
}

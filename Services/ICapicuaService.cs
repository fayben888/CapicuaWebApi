public interface ICapicuaService
{

   
    Task<string> Save(Capicua capicua);
    List<Capicua> GetListCapi();
    bool validateWord(Capicua capicua);
    bool ExistWordValidate(Capicua capicua);
    
}
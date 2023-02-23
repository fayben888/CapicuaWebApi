using Microsoft.AspNetCore.Mvc;

public class CapicuaService : ICapicuaService
{
    private CapicuaContext capicuaContext;
    public CapicuaService([FromServices] CapicuaContext _DBCapicua)
    {
        capicuaContext = _DBCapicua;
        _DBCapicua.Database.EnsureCreated();
    }
    public List<Capicua> GetListCapi()
    {
        return capicuaContext.capicuas.ToList();
    }

    public async Task<string> Save(Capicua capicua)
    {
        try
        {
            if (validateWord(capicua) && ExistWordValidate(capicua))
            {
                //capicua.Created = DateTime.Now;
                capicuaContext.capicuas.Add(capicua);
                await capicuaContext.SaveChangesAsync();
                return "Word was save sucesfull in data base";
            }
            else
            {
                return "Word already exist will'nt save in data base or not is capicua";
            }
        }
        catch (Exception ex)
        {
            return $"has error has ocurred while save word in data base: {ex.Message}";
        }



    }

    public bool validateWord(Capicua capicua)
    {
        string cleanWord = capicua.Word;
        cleanWord = cleanWord.Replace(" ", "").Replace(".", "").Replace("-", "").ToLower();
        bool validate = false;
        char[] ArrWord = cleanWord.ToCharArray();

        for (int letter = 0; letter < ArrWord.Count(); letter++)
        {

            if (ArrWord[letter] == ArrWord[ArrWord.Count() - (letter + 1)])
            {
                validate = true;

            }
            else
            {
                validate = false;
            }
        }

        return validate;
    }

    public bool ExistWordValidate(Capicua capicua)
    {
        int capi = capicuaContext.capicuas.Where(x => x.Word == capicua.Word).Count();

        if (capi == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
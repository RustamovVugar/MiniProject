



using Library_App.Controllers;
using ServiceLayer.Helpers;

LibraryController librarycontroller= new();

while (true)
{
    
    ConsoleColor.Blue.WriteConsole("Select one option");

    ConsoleColor.Blue.WriteConsole("Library option: 1 - create, 2 - get by id, 3 - Delet");

    SelectOption: string option = Console.ReadLine();

    int selectedOption;

    bool isParseOption = int.TryParse(option, out selectedOption);

    if (isParseOption)
    {
        switch (selectedOption)
        {
            case 1:
                librarycontroller.Create();
                break;
            case 2:
                librarycontroller.GetById();
                break;
            case 3:
                Console.WriteLine("Delete");
                break;
            default:
                Console.WriteLine("Select again true option");
                goto SelectOption;
        }
    }
    else
    {

        ConsoleColor.Red.WriteConsole("Select again true option");
      
        goto SelectOption;
    }
}
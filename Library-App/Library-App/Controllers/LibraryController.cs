using DomainLayer.Entities;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_App.Controllers
{
    public  class LibraryController
    {
        private readonly LibraryService _libraryservice;
        public LibraryController()
        {
            _libraryservice = new LibraryService();
        }
        public void Create()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add library name:");

                string name = Console.ReadLine();

                ConsoleColor.DarkMagenta.WriteConsole("Add library seat count:");

            SeatCount: string seatCountStr = Console.ReadLine();

                int seatCount;

                bool isParseSeatcount = int.TryParse(seatCountStr, out seatCount);

                if (isParseSeatcount)
                {
                    Library library = new()
                    {
                        Name = name,
                        SeatCount = seatCount,
                    };

                    var result = _libraryservice.Create(library);

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, SeatCount: {result.SeatCount}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct seat count:");
                    goto SeatCount;
                }
            }
            catch (Exception ex)
            {

                ConsoleColor.Red.WriteConsole(ex.Message); 
            }
           

           

        }

        public void GetById()
        {
            try
            {
                ConsoleColor.DarkMagenta.WriteConsole("Add library id:");

                Id: string idstr= Console.ReadLine();

                int id;

                bool isParseId = int.TryParse(idstr, out id);

                if(isParseId)
                {
                    var result = _libraryservice.GetById(id);
                    if(result != null)
                    {
                        ConsoleColor.Red.WriteConsole("library notfound, please try again:");
                        goto Id;
                    }

                    ConsoleColor.Green.WriteConsole($"Id: {result.Id}, Name: {result.Name}, SeatCount: {result.SeatCount}");
                }
                else
                {
                    ConsoleColor.Red.WriteConsole("Please add correct id:");
                    goto Id ;
                }
            }
            catch (Exception ex)
            {

               ConsoleColor.Red.WriteConsole(ex.Message);
            }
        }
    }
}
 
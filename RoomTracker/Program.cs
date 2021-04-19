using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//************************************
//Title: (Room Tracker)
//Application Type: (framework – Console, )
//Description: (find total square footage )
//Author: (VENYAMIN)
//Date Created: (april 17)
//Last Modified:(april 17)
//************************************

namespace RoomTracker
{
    class Program
    {
        const string TAB = "\t";

        static void Main(string[] args)
        {
            List<Room> rooms;
            rooms = InitializeRooms();

            DisplayWelcomeScreen();
            DisplayMainMenuScreen(rooms);
            DisplayClosingScreen();
        }

        /// <summary>
        /// initialize list of room
        /// </summary>
        /// <returns>list of rooms</returns>
        static List<Room> InitializeRooms()
        {
            List<Room> rooms = new List<Room>();


            //create(instantiate) Room
            
            Room myRoom = new Room();
            myRoom.Id = 1;
            myRoom.Name = "Living Room";
            myRoom.Length = 30;
            myRoom.Width = 30;
            

            Room yourRoom = new Room();
            yourRoom.Id = 2;
            yourRoom.Name = "Dinning room";
            yourRoom.Width = 57;
            yourRoom.Length = 30;
            

            Room theirRoom = new Room(3, "Master Bedroom", 69, 42);

            //
            // add monsters to the list
            //
            rooms.Add(myRoom);
            rooms.Add(yourRoom);
            rooms.Add(theirRoom);

            return rooms;
        }

        /// <summary>
        /// display main menu
        /// </summary>
        /// <param name="monsters">list of monsters</param>
        static void DisplayMainMenuScreen(List<Room> rooms)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Room Tracker Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) View All Rooms");
                Console.WriteLine("\tb) View Room Details");
                Console.WriteLine("\tc) Add Room");
                Console.WriteLine("\td) Delete Room");
                Console.WriteLine("\te) Update Rooms");
                Console.WriteLine("\tf) Total Square Footage");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayAllRooms(rooms);
                        break;

                    case "b":
                        DisplayRoomsDetail(rooms);
                        break;

                    case "c":
                        DisplayAddRoom(rooms);
                        break;

                    case "d":
                        DisplayDeleteRoom(rooms);
                        break;

                    case "e":
                        DisplayUpdateRooms(rooms);
                        break;

                    case "f":
                        DisplayTotalSquareFootage(rooms);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        static void DisplayTotalSquareFootage(List<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                Console.WriteLine(
                TAB +
                room.Name.PadLeft(5)
                );
                double totalSquareFootage = 0;
                totalSquareFootage += room.SquareFootage();
                Console.WriteLine(
                "Total Square Footage".PadLeft(10));
                Console.Write("{0}", totalSquareFootage);
                Console.WriteLine();


            }
            
            
            DisplayContinuePrompt();
            
                
        }

        static void DisplayUpdateRooms(List<Room> rooms)
        {
            string userResponse;

            DisplayScreenHeader("Update Room");

            Room selectedRoom = GetRoomsFromUser(rooms);

            Console.WriteLine();
            Console.WriteLine(TAB + "Enter a new value or pres the Enter key to keep the existing value.");
            Console.WriteLine();

            Console.Write(TAB + $"Name: {selectedRoom.Name} >");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                selectedRoom.Name = userResponse;
            }

            Console.Write(TAB + $"Width: {selectedRoom.Width} >");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                selectedRoom.Width = double.Parse(userResponse);
            }

            Console.Write(TAB + $"Length: {selectedRoom.Length} >");
            userResponse = Console.ReadLine();
            if (userResponse != "")
            {
                selectedRoom.Length = double.Parse(userResponse);
            }



            //DisplayMenuPrompt("Main");
            DisplayContinuePrompt();

        }

        static void DisplayDeleteRoom(List<Room> rooms)
        {
            DisplayScreenHeader("Delete Room");

            Room selectedRoom = GetRoomsFromUser(rooms);

            //
            // confirm deletion with user
            //
            Console.WriteLine();
            Console.WriteLine(TAB + $"{selectedRoom.Name} is about to be deleted.");
            DisplayContinuePrompt();

            //
            // removing monster from list
            //
            rooms.Remove(selectedRoom);

            //
            // confirm that the monster was deleted
            //
            Console.WriteLine();
            Console.WriteLine(TAB + $"{selectedRoom.Name} has been deleted.");

            //DisplayMenuPrompt("Main");
            DisplayContinuePrompt();

        }

        static void DisplayRoomsDetail(List<Room> rooms)
        {
            DisplayScreenHeader("Room Detail");

            Room selectedRoom = GetRoomsFromUser(rooms);

            //
            // display the monster detail
            //
            Console.WriteLine();
            Console.WriteLine(TAB + $"Name: {selectedRoom.Name}");
            Console.WriteLine(TAB + $"Width: {selectedRoom.Width}");
            Console.WriteLine(TAB + $"Length: {selectedRoom.Length}");


            //DisplayMenuPrompt("Main");
            DisplayContinuePrompt();

        }

        static Room GetRoomsFromUser(List<Room> rooms)
        {
            //
            // get monster id from user
            //
            //DisplayRoomTable(rooms);
            Console.Write(TAB + "Enter the Id of the room:");
            int id = int.Parse(Console.ReadLine());

            //
            // get the monster from the list
            //
            Room selectedRoom = null;
            foreach (Room room in rooms)
            {
                if (room.Id == id)
                {
                    selectedRoom = room;
                    break;
                }
            }

            return selectedRoom;
        }


        /// <summary>
        /// add a new room
        /// </summary>
        /// <param name="rooms">list of rooms</param>
        static void DisplayAddRoom(List<Room> rooms)
        { 
            DisplayScreenHeader("Add Room");

            Room newRoom = new Room();

            Console.Write(TAB + "Id:");
            newRoom.Id = int.Parse(Console.ReadLine());

            Console.Write(TAB + "Name:");
            newRoom.Name = Console.ReadLine();

            Console.Write(TAB + "Width:");
            newRoom.Width = double.Parse(Console.ReadLine());

            Console.Write(TAB + "Length:");
            newRoom.Length = double.Parse(Console.ReadLine());


            rooms.Add(newRoom);

            //DisplayMenuPrompt("Main");
            DisplayContinuePrompt();

        }

        /// <summary>
        /// display all rooms in a table
        /// </summary>
        /// <param name="rooms">list of rooms</param>
        static void DisplayAllRooms(List<Room> rooms)
        {
            DisplayScreenHeader("All Rooms");
            //DisplayRoomTable(rooms);
            Console.WriteLine(
                TAB +
                "Id".PadLeft(5) +
                "Name".PadLeft(15) +
                "width".PadLeft(10) +
                "length".PadLeft(10) +
                "square footage".PadLeft(20)
                );
            Console.WriteLine(
                TAB +
                "---".PadLeft(5) +
                "----".PadLeft(15) +
                "-----".PadLeft(10) +
                "------".PadLeft(10) +
                "--------------".PadLeft(20)
                );
            foreach (Room room in rooms)
                Console.WriteLine(
                TAB +
                room.Id.ToString().PadLeft(5) +
                room.Name.PadLeft(15) +
                room.Width.ToString().PadLeft(10) +
                room.Length.ToString().PadLeft(10) +
                room.SquareFootage().ToString().PadLeft(10)
                );

            DisplayContinuePrompt();
        }

        static void DisplayRoomTable(List<Room> rooms)
        {
            Console.WriteLine(
                TAB +
                "Id".PadLeft(5) +
                "Name".PadLeft(15) +
                "width".PadLeft(10) +
                "length".PadLeft(10) +
                "square footage".PadLeft(20)
                );
            Console.WriteLine(
                TAB +
                "---".PadLeft(5) +
                "----".PadLeft(15) +
                "-----".PadLeft(10) +
                "------".PadLeft(10) +
                "--------------".PadLeft(20)
                );
            double totalSquareFootage = 0;
            foreach (Room room in rooms)
            {
                Console.WriteLine(
                TAB +
                room.Id.ToString().PadLeft(5) +
                room.Name.PadLeft(15) +
                room.Width.ToString().PadLeft(10) +
                room.Length.ToString().PadLeft(10) +
                room.SquareFootage().ToString().PadLeft(10)
                );

                totalSquareFootage += room.SquareFootage();
                Console.WriteLine(

                "Total Square Footage".PadLeft(10));
                Console.Write("{0}", totalSquareFootage);
                Console.WriteLine();
                
            }
            //DisplayMenuPrompt("Main");
            DisplayContinuePrompt();
            
            
            

        }

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tRoom Tracker");
            Console.WriteLine();
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t\tThank you for using Room Tracker!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\t\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
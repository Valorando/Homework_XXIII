/*Создание базы данных и таблицы

Создайте базу данных SQLite с названием "LibraryDB".
Создайте таблицу Books с следующими полями:
ID (int, primary key, autoincrement)
Title (string)
Author (string)
PublicationYear (int)
Genre (string)
ISBN (string)
CRUD-операции

Создание (Create)
Реализуйте возможность добавления новых книг в базу данных.
Чтение (Read)
Реализуйте возможность просмотра списка всех книг.
Реализуйте возможность поиска книги по различным критериям (например, по ID, названию, автору).
Обновление (Update)
Реализуйте возможность обновления информации о книге (например, изменение автора или названия).
Удаление (Delete)
Реализуйте возможность удаления книги из базы данных.
Пользовательский интерфейс

Разработайте консольный интерфейс для взаимодействия с пользователем.
Интерфейс должен быть интуитивно понятным и предоставлять информацию о доступных командах и формате их использования.*/

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_21_09
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Green;

            while (true)
            {
                
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 1 для просмотра списка книг.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 2 для поиска книги.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 3 для добавления книги в список.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 4 для обновления информации о книге.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 5 для удаления книги из списка.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine(" * Нажмите 6 для выхода из программы.");
                    Console.WriteLine("==========================================================");
                    Console.WriteLine();
                    ConsoleKeyInfo key = Console.ReadKey();

                    if (key.Key == ConsoleKey.D1)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Опция 1 - Просмотр списка книг.");
                        Console.WriteLine();

                        try
                        {
                            string request = "SELECT * FROM Books";
                            using(var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                            {
                                connection.Open();

                                SQLiteCommand command = new SQLiteCommand(request, connection);

                                using(SQLiteDataReader reader = command.ExecuteReader())
                                {
                                    if(reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            var id = reader.GetValue(0);
                                            var title = reader.GetValue(1);
                                            var author = reader.GetValue(2);
                                            var publication_year = reader.GetValue(3);
                                            var genre = reader.GetValue(4);
                                            var isbn = reader.GetValue(5);


                                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                        }
                                    }
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key.Key == ConsoleKey.D2)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Опция 2 - Поиск книги.");
                        Console.WriteLine();

                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 1 для поиска книги по ID.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 2 для поиска книги по названию.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 3 для поиска книги по автору.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 4 для поиска книги по году выпуска.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 5 для поиска книги по жанру.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 6 для поиска книги по ISBN.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 7 для возврата в основное меню.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine();

                            ConsoleKeyInfo key_two = Console.ReadKey();

                            if (key_two.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE ID = '{id}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id_ = reader.GetValue(0);
                                                var title = reader.GetValue(1);
                                                var author = reader.GetValue(2);
                                                var publication_year = reader.GetValue(3);
                                                var genre = reader.GetValue(4);
                                                var isbn = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine();
                                Console.Write("Введите название книги: ");
                                string title = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE Title = '{title}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id = reader.GetValue(0);
                                                var title_ = reader.GetValue(1);
                                                var author = reader.GetValue(2);
                                                var publication_year = reader.GetValue(3);
                                                var genre = reader.GetValue(4);
                                                var isbn = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D3)
                            {
                                Console.WriteLine();
                                Console.Write("Введите автора книги: ");
                                string author = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE Author = '{author}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id = reader.GetValue(0);
                                                var title = reader.GetValue(1);
                                                var author_ = reader.GetValue(2);
                                                var publication_year = reader.GetValue(3);
                                                var genre = reader.GetValue(4);
                                                var isbn = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D4)
                            {
                                Console.WriteLine();
                                Console.Write("Введите год выпуска книги: ");
                                int publication_year = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE PublicationYear = '{publication_year}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id = reader.GetValue(0);
                                                var title = reader.GetValue(1);
                                                var author = reader.GetValue(2);
                                                var publication_year_ = reader.GetValue(3);
                                                var genre = reader.GetValue(4);
                                                var isbn = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D5)
                            {
                                Console.WriteLine();
                                Console.Write("Введите жанр книги: ");
                                string genre = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE Genre = '{genre}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id = reader.GetValue(0);
                                                var title = reader.GetValue(1);
                                                var author = reader.GetValue(2);
                                                var publication_year = reader.GetValue(3);
                                                var genre_ = reader.GetValue(4);
                                                var isbn = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D6)
                            {
                                Console.WriteLine();
                                Console.Write("ISBN книги: ");
                                string isbn = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"SELECT ID, Title, Author, PublicationYear, Genre, ISBN FROM Books WHERE ISBN = '{isbn}'";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand(request, connection);

                                    using (SQLiteDataReader reader = command.ExecuteReader())
                                    {
                                        if (reader.HasRows)
                                        {
                                            while (reader.Read())
                                            {
                                                var id = reader.GetValue(0);
                                                var title = reader.GetValue(1);
                                                var author = reader.GetValue(2);
                                                var publication_year = reader.GetValue(3);
                                                var genre = reader.GetValue(4);
                                                var isbn_ = reader.GetValue(5);

                                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                                                Console.WriteLine($"|{id}| Название: {title}\t Автор: {author}\t Год: {publication_year}\t Жанр: {genre}\t ISBN: {isbn}");

                                            }
                                        }
                                    }

                                }
                            }

                            if (key_two.Key == ConsoleKey.D7)
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key.Key == ConsoleKey.D3)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Опция 3 - Добавление книги.");
                        Console.WriteLine();

                        try
                        {
                            Console.Write("Введите название книги: ");
                            string book_name = Console.ReadLine();
                            Console.Write("Введите автора: ");
                            string author = Console.ReadLine();
                            Console.Write("Введите год публикации: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите жанр: ");
                            string genre = Console.ReadLine();
                            Console.Write("Введите ISBN: ");
                            string isbn = Console.ReadLine();

                            string request = $"INSERT INTO Books(Title, Author, PublicationYear, Genre, ISBN) VALUES ('{book_name}', '{author}', {year}, '{genre}', '{isbn}')";

                            using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                            {
                                connection.Open();

                                SQLiteCommand command = new SQLiteCommand();
                                command.Connection = connection;

                                command.CommandText = request;
                                command.ExecuteNonQuery();

                                Console.WriteLine("Добавление выполнено.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key.Key == ConsoleKey.D4)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Опция 4 - Обновление информации о книге.");
                        Console.WriteLine();

                        try
                        {
                            Console.WriteLine();
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 1 для обновления названия книги.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 2 для обновления автора книги.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 3 для обновления года выпуска книги.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 4 для обновления жанра книги.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 5 для обновления ISBN книги.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine(" * Нажмите 6 для возврата в основное меню.");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine();

                            ConsoleKeyInfo key_three = Console.ReadKey();

                            if(key_three.Key == ConsoleKey.D1)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите новое название книги: ");
                                string new_title = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"UPDATE Books SET Title = '{new_title}' WHERE ID = {id}";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand();
                                    command.Connection = connection;

                                    command.CommandText = request;
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("Обновление выполнено.");
                                }
                            }

                            if (key_three.Key == ConsoleKey.D2)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите нового автора книги: ");
                                string new_author = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"UPDATE Books SET Author = '{new_author}' WHERE ID = {id}";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand();
                                    command.Connection = connection;

                                    command.CommandText = request;
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("Обновление выполнено.");
                                }
                            }

                            if (key_three.Key == ConsoleKey.D3)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите новый год выпуска книги: ");
                                int new_year = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();

                                string request = $"UPDATE Books SET PublicationYear = '{new_year}' WHERE ID = {id}";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand();
                                    command.Connection = connection;

                                    command.CommandText = request;
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("Обновление выполнено.");
                                }
                            }

                            if (key_three.Key == ConsoleKey.D4)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите новый жанр книги: ");
                                string new_genre = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"UPDATE Books SET Genre = '{new_genre}' WHERE ID = {id}";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand();
                                    command.Connection = connection;

                                    command.CommandText = request;
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("Обновление выполнено.");
                                }
                            }

                            if (key_three.Key == ConsoleKey.D5)
                            {
                                Console.WriteLine();
                                Console.Write("Введите ID книги: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Введите новый ISBN книги: ");
                                string new_isbn = Console.ReadLine();
                                Console.WriteLine();

                                string request = $"UPDATE Books SET ISBN = '{new_isbn}' WHERE ID = {id}";

                                using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                                {
                                    connection.Open();

                                    SQLiteCommand command = new SQLiteCommand();
                                    command.Connection = connection;

                                    command.CommandText = request;
                                    command.ExecuteNonQuery();

                                    Console.WriteLine("Обновление выполнено.");
                                }
                            }

                            if (key_three.Key == ConsoleKey.D6)
                            {

                            }

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key.Key == ConsoleKey.D5)
                    {
                        Console.WriteLine();
                        Console.WriteLine(" Опция 5 - Удаление книги.");
                        Console.WriteLine();

                        try
                        {
                            Console.WriteLine();
                            Console.Write("Введите ID книги которую нужно удалить: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            string request = $"DELETE FROM Books WHERE ID = {id}";

                            using (var connection = new SQLiteConnection("Data Source = LibraryDB.db"))
                            {
                                connection.Open();

                                SQLiteCommand command = new SQLiteCommand();
                                command.Connection = connection;

                                command.CommandText = request;
                                command.ExecuteNonQuery();

                                Console.WriteLine("Удаление выполнено.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Ошибка: {ex.Message}");
                            Console.WriteLine();
                        }
                    }

                    if (key.Key == ConsoleKey.D6)
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine();
                }
            }

            
        }
    }
}

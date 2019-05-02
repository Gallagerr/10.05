using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbUpLesson
{
  public class Menu
  {
    private readonly string connectionString;
    private List<News> news;
    private List<Comments> comments;

    public void Choices()
    {
      Console.WriteLine("1) Ввеcти новость\n" + "2) Ввести коментари");
      int choice = int.Parse(Console.ReadLine());

      if (choice == 1)
      {
        AddNews();
      }
      else if (choice == 2)
      {
        Addcomments();
      }
    }

    public void AddNews()
    {
      News newNewss = new News();
      Console.WriteLine("Введите новость");
      newNewss.Newss = Console.ReadLine();

      using (var connection = new SqlConnection(connectionString))
      {
        connection.Execute("insert into News values(@Newss)", newNewss);
      }
    }
      public  void Addcomments()
      { 
           if (int.TryParse(Console.ReadLine(), out int index))
           {
             if (index > 0 && index <= news.Count)
             {
               string comment;
               Guid id = news[index - 1].Id;
               Console.WriteLine("Введите коменттарий");
               comment = Console.ReadLine();
        
               using (var connection = new SqlConnection(connectionString))
               {
                 Comments newscomment = new Comments();
                 newscomment.NewsId = id;
                 newscomment.Comment = comment;
        
                 connection.Execute("insert into Comments values(@Comment, @NewsId)", newscomment);
               }
             }
           }   
      }
  }
}


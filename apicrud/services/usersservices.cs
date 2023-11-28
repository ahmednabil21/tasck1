using apicrud.Models;

namespace apicrud.services
{
    public class usersservices
    {
        static List<users> usersLists { get; }
        static int nextuseid = 6;
        static usersservices()
        {
            usersLists = new List<users>()
            {
                new users{Id =1 ,Name="ahmed ali",Email="@yahootask",Username="glg@13",Password=9090},
                new users{Id =2 ,Name="wesaam ali",Email="@yahootask2",Username="glg@14",Password=9090},
                new users{Id =3 ,Name="hameed slman",Email="@yahootask3",Username="glg@15",Password=9090},
                new users{Id =4 ,Name="murtada raad",Email="@yahootask3",Username="glg@16",Password=9090}

            };
        }
        public static List<users> GetAll() => usersLists;

        public static users Get(int id) => usersLists.FirstOrDefault(p => p.Id == id);


        public static void Add(users users)

        {
            users.Id = nextuseid++;
            usersLists.Add(users);

        }
        public static void update(users users)
        {
            var index = usersLists.FindIndex(p => p.Id == users.Id);
            if (index == -1)
                return;
            usersLists[index] = users;
        }
        public static void delete(int id)
        {
            var employe = Get(id);
            if (employe is null)
                return;

            usersLists.Remove(employe);
        }

    }


}       
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using Entity;
using System.Windows.Forms;

namespace Control
{
    public class DBConnector
    {

        private SQLiteConnection _connection;
        private SQLiteCommand _cmd;
        private SQLiteDataReader _reader;

        public DBConnector()
        {
            _connection = new SQLiteConnection("Data Source=movieticketing.db");
            _connection.Open();
            _cmd = _connection.CreateCommand();

            _cmd.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%';";
            _reader = _cmd.ExecuteReader();

            if (!_reader.HasRows)
            {
                _reader.Close();
                InitializeDatabase();
            }
            //DropTables();
            _reader.Close();
        }
        private void InitializeDatabase()
        {
            foreach (var table in new string[]
                { "CREATE TABLE Poster (MovieTitle varchar(200) primary key, ImgPath varchar(200));",
                     "CREATE TABLE Theater (Id integer primary key, TotalCapacity integer)",
                     "CREATE TABLE MovieEntry(Id integer primary key, Title varchar(200), Date varchar(25), Start varchar(50), End varchar(50), Theater integer, CurrentCapacity integer, FOREIGN KEY(Title) REFERENCES Poster(MovieTitle), FOREIGN KEY(Theater) REFERENCES Theater(Id));",
                     "CREATE TABLE Reservation (Id integer primary key, Movie integer, NumSeats integer, FOREIGN KEY(Movie) REFERENCES MovieEntry(Id));",
                     "CREATE TABLE User (Username varchar(5) primary key, Password varchar(100));",
                     "CREATE TABLE UserSession (User varchar(5), LoginTime varchar(100), LogoutTime varchar(100), PRIMARY KEY(User, LoginTime), FOREIGN KEY(User) REFERENCES User(Username));"
                })
            {
                _cmd.CommandText = table;
                _cmd.ExecuteNonQuery();
            }

            AddPosters();
            AddTheaters();
            AddUsers();
        }

        private void DropTables()
        {
            string[] arr = new string[6];
            int i = 0;
            while (_reader.Read())
            {
                string s = "DROP TABLE " + _reader.GetString(0);
                arr[i++] = s;
            }
            _reader.Close();
            foreach (var table in arr)
            {
                if (table != null)
                {
                    _cmd.CommandText = table;
                    _cmd.ExecuteNonQuery();
                }
            }

        }

        private void AddPosters()
        {
            string common = "Insert into Poster(MovieTitle, ImgPath) VALUES (";

            string cd = Environment.CurrentDirectory;
            DirectoryInfo[] folders = Directory.GetParent(cd).Parent.GetDirectories("Posters");
            FileInfo[] paths = folders[0].GetFiles();  //list of poster paths

            StreamReader readTitles = new StreamReader("movieTitles.txt"); //list of movie titles associated with poster paths
            StringBuilder sb = new StringBuilder();

            string title = readTitles.ReadLine();
            int result = 0;
            for (int i = 0; i < paths.Length && title != null; i++)
            {
                sb.Append(common);
                sb.Append("'");
                sb.Append(title);
                sb.Append("', '");
                sb.Append(paths[i].DirectoryName + "\\" + paths[i]);
                sb.Append("');");
                _cmd.CommandText = sb.ToString();
                result += _cmd.ExecuteNonQuery();
                title = readTitles.ReadLine();
                sb.Clear();
            }
            MessageBox.Show(result.ToString());
        }

        private void AddTheaters()
        {
            string common = "Insert into Theater(Id, TotalCapacity) VALUES (";
            int result = 0;
            for (int i = 1; i < 13; i++)
            {
                _cmd.CommandText = common + $"{i}, 20);";
                result += _cmd.ExecuteNonQuery();
            }
            MessageBox.Show(result.ToString());
        }

        private void AddUsers()
        {
            StreamReader readUsers = new StreamReader("users.txt");
            List<string[]> users = new List<string[]>();
            string[] credentials;

            string line = readUsers.ReadLine();

            while (line != null)
            {
                credentials = line.Split(new char[] { ',' });
                users.Add(credentials);
                line = readUsers.ReadLine();
            }

            int result = 0;
            foreach (var user in users)
            {
                _cmd.CommandText = $"INSERT INTO User(Username, Password) VALUES ('{user[0].Trim()}', '{user[1].Trim()}');";
                result += _cmd.ExecuteNonQuery();
            }
            MessageBox.Show(result.ToString());
        }
        public void Save(MovieEntry entry)
        {
            CheckForConflicts(entry); //initial scan to throw out showtimes that conflict with existing showtimes

            _cmd.CommandText = $"Select TotalCapacity from Theater where Id={entry.Theatre}";
            _reader = _cmd.ExecuteReader();
            _reader.Read();
            int total = _reader.GetInt32(0);
            _reader.Close();

            string common = "Insert into MovieEntry(Title, Date, Start, End, Theater, CurrentCapacity) VALUES ('";
            StringBuilder sb = new StringBuilder();

            foreach (var showtime in entry.Showings)
            {
                if (showtime.Start == null) //skip showtimes flagged as duplicate in CheckForConflicts()
                    continue;
                sb.Append(common);
                sb.Append(entry.Title);
                sb.Append("', '");
                sb.Append(((DateTime)showtime.Start).Date.ToString("d"));
                sb.Append("', '");
                sb.Append(((DateTime)showtime.Start).ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("', '");
                sb.Append(((DateTime)showtime.End).ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("', ");
                sb.Append(entry.Theatre);
                sb.Append(", ");
                sb.Append(total);
                sb.Append(");");

                _cmd.CommandText = sb.ToString();
                _cmd.ExecuteNonQuery();
                sb.Clear();
            }
        }

        private void CheckForConflicts(MovieEntry entry)
        {
            StringBuilder sb = new StringBuilder();
            string common = $"SELECT Id FROM MovieEntry WHERE Theater={entry.Theatre} ";

            foreach (var showtime in entry.Showings)
            {
                sb.Append(common);
                sb.Append($"AND Start BETWEEN '{((DateTime)showtime.Start).ToString("yyyy-MM-dd HH:mm:ss")}' AND '{((DateTime)showtime.End).ToString("yyyy-MM-dd HH:mm:ss")}' ");
                sb.Append("UNION ");
                sb.Append(common);
                sb.Append($"AND '{((DateTime)showtime.Start).ToString("yyyy-MM-dd HH:mm:ss")}' BETWEEN Start AND End ");
                sb.Append("UNION ");
                sb.Append(common);
                sb.Append($"AND '{((DateTime)showtime.End).ToString("yyyy-MM-dd HH:mm:ss")}' BETWEEN Start AND End;");

                _cmd.CommandText = sb.ToString();
                _reader = _cmd.ExecuteReader();
                
                if (_reader.HasRows)
                    showtime.Start = null; //flag duplicate showtimes
                
                _reader.Close();
                sb.Clear();
            }
        }

        public List<MovieEntry> GetMovieEntries(DateTime date)
        {
            List<MovieEntry> results = new List<MovieEntry>();
            _cmd.CommandText = $"SELECT Id, Theater, Title, Start, End, CurrentCapacity, ImgPath FROM MovieEntry INNER JOIN Poster ON Poster.MovieTitle=MovieEntry.Title WHERE Date='{date.Date.ToString("d")}'";
            _reader = _cmd.ExecuteReader();

            while (_reader.Read())
            {
                DateTime start=DateTime.ParseExact(_reader.GetString(3), "yyyy-MM-dd HH:mm:ss", null);
                DateTime end =DateTime.ParseExact(_reader.GetString(4), "yyyy-MM-dd HH:mm:ss", null);
                MovieEntry entry = new MovieEntry(_reader.GetInt32(0), _reader.GetInt32(1), _reader.GetString(2), new Showtime(start, end), _reader.GetInt32(5), _reader.GetString(6));

                results.Add(entry);
            }
            _reader.Close();
            return results;
        }

        public long Save(Reservation res)
        {
            /*Assuming that only one user is using system at once, 
             * no concurrent access implies we don't have to check 
             * if res.MovieEntry's CurrentCapacity can be safely decremented by NumSeats 
             */
            _cmd.CommandText = $"INSERT INTO Reservation(Movie, NumSeats) VALUES ({res.MovieEntry.Id}, {res.NumSeats});";
            _cmd.ExecuteNonQuery();

            _cmd.CommandText = $"SELECT CurrentCapacity FROM MovieEntry WHERE Id={res.MovieEntry.Id}";
            _reader = _cmd.ExecuteReader();
            _reader.Read();
            int currCap = _reader.GetInt32(0);
            _reader.Close();

            currCap -= res.NumSeats;

            _cmd.CommandText = $"UPDATE MovieEntry SET CurrentCapacity={currCap} WHERE Id={res.MovieEntry.Id}";
            _cmd.ExecuteNonQuery();

            return _connection.LastInsertRowId;
        }
        public Poster GetPoster(string title)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Select * from Poster where MovieTitle=");
            sb.Append("'" + title + "';");

            _cmd.CommandText = sb.ToString();
            _reader = _cmd.ExecuteReader();

            Poster poster = null;

            if (_reader.Read())
                poster = new Poster(_reader.GetString(0), _reader.GetString(1));

            _reader.Close();

            return poster;
        }

        public string Authenticate(string username, string hashpw)
        {
            _cmd.CommandText = $"SELECT Password FROM User WHERE Username='{username}';";
            _reader = _cmd.ExecuteReader();

            string token = "";

            if (_reader.HasRows)
            {
                _reader.Read();

                if (hashpw == _reader.GetString(0))
                {
                    _reader.Close();
                    token = RecordLogin(username);
                }
            }
            if (!_reader.IsClosed)
                _reader.Close();
            return token;
        }

        private string RecordLogin(string username)
        {
            string loginTime = DateTime.Now.ToString("G");
            _cmd.CommandText = $"INSERT INTO UserSession(User, LoginTime) VALUES ('{username}', '{loginTime}');";
            MessageBox.Show(_cmd.ExecuteNonQuery().ToString());

            return username + "_" + loginTime;
        }

        public bool RecordLogout(string token)
        {
            string[] keys = token.Split(new char[] { '_' });
            _cmd.CommandText = $"UPDATE UserSession SET LogoutTime='{DateTime.Now.ToString("G")}' WHERE User='{keys[0]}' AND LoginTime='{keys[1]}';";
            return _cmd.ExecuteNonQuery() != 0;
        }

    }
}

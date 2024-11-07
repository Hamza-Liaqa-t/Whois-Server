using MySql.Data;
using MySql.Data.MySqlClient;

string connStr = "server=localhost;user=root;database=umdb;port=3306;password=Sausage123";
MySqlConnection conn = new MySqlConnection(connStr);

Console.WriteLine("Enter Prompt");
string prompt = Console.ReadLine();

//put the if statement in while loop
while (true)
{
    if (prompt != null)
    {
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT * FROM login";
            MySqlCommand cmd = new MySqlCommand(prompt, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " -- " + rdr[1]); //+ " -- " + rdr[2] + " -- " + rdr[3] + " -- " + rdr[4]);
            }
            Console.WriteLine("Done.");
            Console.WriteLine("Enter Prompt or press enter to exit");
            string repeat = Console.ReadLine();
            if (repeat == "")
            {
                break;
                rdr.Close();
            }
            else
            {
                prompt = repeat;
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        conn.Close();
    }
}







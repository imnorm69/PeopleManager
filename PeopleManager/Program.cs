using PeopleManager.Data;
using PeopleManager.Forms;

namespace PeopleManager;

static class Program
{
    [STAThread]
    static async Task Main()
    {
        ApplicationConfiguration.Initialize();
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        // Ensure DB exists
        try
        {
            await DbFactory.InitializeDatabaseAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Could not connect to the database.\n\n{ex.Message}",
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        Application.Run(new MainForm());
    }
}

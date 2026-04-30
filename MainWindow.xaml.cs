using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeExam.Module;

using Microsoft.EntityFrameworkCore;
namespace TimeExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        appDbContext db;
        public MainWindow()
        {
        
            
            db = new appDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InitializeComponent();
         
        }
    }
}
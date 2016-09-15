using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dictionary
{
    public class Presenter
    {
        private Model model;
        private MainWindow mainWindow;
        private Word Editable = new Word();
        private List<Word> list = new List<Word>();


        public Presenter(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            model = new Model();

            this.mainWindow.SearchClick += MainWindow_SearchClick;
            this.mainWindow.ClickAlphabet += MainWindow_ClickAlphabet;
            this.mainWindow.RestoreDef += MainWindow_RestoreDef;
            this.mainWindow.MakeBackup += MainWindow_MakeBackup;
            this.mainWindow.RestoreBackup += MainWindow_RestoreBackup;
            this.mainWindow.Edit += MainWindow_Edit;
            this.mainWindow.ListSelect += MainWindow_ListSelect;
            this.mainWindow.Add += MainWindow_Add;
            this.mainWindow.Remove += MainWindow_Remove;
        }


        private void MainWindow_ListSelect(object sender, EventArgs e)
        {
            model.SetEditable(ref sender);
        }
        private void MainWindow_ClickAlphabet(object sender, EventArgs e)
        {

            Button temp = (Button)sender;
            string word = temp.Content.ToString();


            mainWindow.listView.ItemsSource = null;
            list.Clear();

            list = model.Search(list, word.ToLower().First());
            mainWindow.listView.ItemsSource = list;
        }
        private void MainWindow_SearchClick(object sender, EventArgs e)
        {
            mainWindow.listView.ItemsSource = null;
            list.Clear();
            list = model.Search(list, mainWindow.textBoxSearch.Text.ToLower());
            mainWindow.listView.ItemsSource = list;
        }        
        private void MainWindow_Add(object sender, EventArgs e)
        {          
            list.Clear();
            mainWindow.listView.ItemsSource = null;

            list = model.Insert(list, mainWindow.textBoxTermin.Text.ToLower(), mainWindow.textBoxDescription.Text.ToLower());

            mainWindow.listView.ItemsSource = list;       
        }        
        private void MainWindow_Edit(object sender, EventArgs e)
        {
            mainWindow.listView.ItemsSource = null;
            list.Clear();

            list = model.Edit(mainWindow.textBoxDescription.Text.ToLower(), list);

            mainWindow.listView.ItemsSource = list;
        }
        private void MainWindow_Remove(object sender, EventArgs e)
        {
            list.Clear();
            mainWindow.listView.ItemsSource = null;

            list = model.Delete(list);

            mainWindow.listView.ItemsSource = list;

        }


        private void MainWindow_RestoreBackup(object sender, EventArgs e)
        {
            list.Clear();
            mainWindow.listView.ItemsSource = null;

            model.RestoreBackup(sender.ToString().Last());
            
            list = model.Search(list);

            mainWindow.listView.ItemsSource = list;
        }
        private void MainWindow_MakeBackup(object sender, EventArgs e)
        {
            model.MakeBackup(sender.ToString().Last());
        }
        private void MainWindow_RestoreDef(object sender, EventArgs e)
        {
            list.Clear();
            mainWindow.listView.ItemsSource = null;


            model.RestoreDefault();

            list = model.Search(list);
            mainWindow.listView.ItemsSource = list;
        }


    }
}

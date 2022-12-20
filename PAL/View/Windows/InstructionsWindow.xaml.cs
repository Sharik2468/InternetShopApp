using Microsoft.VisualStudio.TestPlatform.TestHost;
using PAL.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

namespace PL.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для InstructionsWindow.xaml
    /// </summary>
    public partial class InstructionsWindow : Page
    {
        public InstructionsWindow()
        {
            InitializeComponent();
        }

        private static Page Instructions = null;
        public static Page getInstance()
        {
            if (Instructions == null)
            {
                Instructions = new InstructionsWindow();
            }
            return Instructions;
        }
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Start.getInstance());
        }

        private void Basket_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Basket.getInstance());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Profile.getInstance());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(Settings.getInstance());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var path = Directory.GetCurrentDirectory();
            //path.Remove(path.Length - 29, 28);
            for (int i = 0; i < 3; i++)
            { 
                path = System.IO.Path.GetDirectoryName(path); 
            }
            System.Diagnostics.Process.Start("explorer", path+"\\Instructions\\Instructions.gui");
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();
            // Create a Run of plain text and some bold text.
            Run myRun = new Run("Данное приложение позволяет покупать товары, которые добавили продавцы. Также продавцы могут продавать любой товар , который им больше не нужен");

            // Create a paragraph and add the Run and Bold to it.
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(myRun);

            // Add the paragraph to the FlowDocument.
            myFlowDoc.Blocks.Add(myParagraph);

            InstructionPole.Document = myFlowDoc;
        }

        private void TreeViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            // Create a FlowDocument to contain content for the RichTextBox.
            FlowDocument myFlowDoc = new FlowDocument();
            // Create a Run of plain text and some bold text.
            Run myRun = new Run("Шарабанов Никита Александрович Группа 3-42хх");

            // Create a paragraph and add the Run and Bold to it.
            Paragraph myParagraph = new Paragraph();
            myParagraph.Inlines.Add(myRun);

            // Add the paragraph to the FlowDocument.
            myFlowDoc.Blocks.Add(myParagraph);

            InstructionPole.Document = myFlowDoc;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TextEditorMVC.Text
{
	/// <summary>
	/// Interaction logic for TextExample.xaml
	/// </summary>
	public partial class TextExample : Window
	{
		public TextExample()
		{
			InitializeComponent();

			title.Content = "Диагностика и нейтрализация ошибок";

			pic1.Text = "Рисунок 3 - Текстовый пример с наличием ошибок";
			pic2.Text = "Рисунок 4 - Текстовый пример с наличием ошибок";
			pic3.Text = "Рисунок 5 - Текстовый пример с наличием ошибок";
			pic4.Text = "Рисунок 6 - Текстовый пример с наличием ошибок";

		}
	}
}

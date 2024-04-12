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
	/// Interaction logic for FormulationOfTheProblem.xaml
	/// </summary>
	public partial class FormulationOfTheProblem : Window
	{
		public FormulationOfTheProblem()
		{
			InitializeComponent();
			title.Content = "Постановка задачи";
			ContentLabel.Text =
@"
Константы – это элементы данных, значения которых известны и в процессе выполнения программы не изменяются.

Для описания вещественных констант в языке Kotlin используются служебные слова ""const"", ""val"", ""Double"".

Формат записи: ""const val имя_константы: Double=значение;"".

Примеры:
1.	Вещественная константа с фиксированной точкой со знаком или без него – число представленное в виде целой и дробной частей разделенных точкой: ""const val myConst: Double =-39.1;""
2.	Целая десятичная константа – любое десятичное число без десятичной точки со знаком или без него: ""const val myConst: Double = 128;"".

В связи с разработанной автоматной грамматикой G[‹DEF›] синтаксический анализатор (парсер) десятичных констант будет считать верными следующие записи констант:
1.	""const val myConst: Double = +2;""
2.	""const val myConst: Double = 2.32;""
3.	""const val myConst: Double = -2.1;""

";

		}
	}
}

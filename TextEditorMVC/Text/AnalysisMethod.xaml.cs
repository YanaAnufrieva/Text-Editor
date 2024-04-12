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
	/// Interaction logic for AnalysisMethod.xaml
	/// </summary>
	public partial class AnalysisMethod : Window
	{
		public AnalysisMethod()
		{
			InitializeComponent();

			title.Content = "Метод анализа";
			ContentLabel.Text =
@"
Грамматика G[‹DEF›] является автоматной.

Правила (1) – (15) для G[‹DEF›] реализованы на графе (см. рисунок 1).

Сплошные стрелки на графе характеризуют синтаксически верный разбор; пунктирные символизируют состояние ошибки (ERROR); дуга λ и непоме-ченные дуги предполагают любой терминальный символ, отличный от указанного из соответствующего узла.

";

			ContentLabel2.Text = 
@"Рисунок 1 - граф G[‹DEF›]


";
		}
	}
}

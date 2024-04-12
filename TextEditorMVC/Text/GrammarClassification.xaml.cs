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
	/// Interaction logic for GrammarClassification.xaml
	/// </summary>
	public partial class GrammarClassification : Window
	{
		public GrammarClassification()
		{
			InitializeComponent();
			title.Content = "Классификация грамматики";
			ContentLabel.Text =
@"
Согласно классификации Хомского, грамматика G[‹DEF›] является автоматной.

Правила (1)-(15) относятся к классу праворекурсивных продукций (A → aB | a | ε):

	1.	‹DEF› -> 'const' ‹CONST›
	2.	‹CONST› -> ' ' ‹SPACE›
	3.	‹SPACE› -> 'val' ‹VAL›<
	4.	‹VAL› -> ' ' ‹ID›
	5.	‹ID› -> (‹Letter›|'_') ‹IDREM›
	6.	‹IDREM› -> (‹Letter›|'_'|‹Digit›) ‹IDREM›
	7.	‹IDREM› -> ':' ‹TYPE›
	8.	‹TYPE› -> '‹Double' ‹EQUAL›
	9.	‹EQUAL› -> '=' ‹DOUBLE›
	10.	‹DOUBLE› -> [+|-] ‹NUMBER›
	11.	‹NUMBER› -> ‹Digit› ‹NUMBERREM›
	12.	‹NUMBERREM› -> ‹Digit› ‹NUMBERREM› | ';'
	13.	‹NUMBERREM› -> '.' ‹DECIMAL›
	14.	‹DECIMAL› -> ‹Digit› ‹DECIMALREM›
	15.	‹DECIMALREM› -> ‹Digit› ‹DECIMALREM› | ';'

";
		}
	}
}

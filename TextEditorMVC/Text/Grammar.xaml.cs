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
	/// Interaction logic for Grammar.xaml
	/// </summary>
	public partial class Grammar : Window
	{
		public Grammar()
		{
			InitializeComponent();
			title.Content = "Грамматика";
			ContentLabel.Text =
@"Определим грамматику вещественных констант языка Kotlin G[‹DEF›] в нотации Хомского с продукциями P:

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

	•	‹Digit› → “0” | “1” | “2” | “3” | “4” | “5” | “6” | “7” | “8” | “9”
	•	‹Letter› → “a” | “b” | “c” | ... | “z” | “A” | “B” | “C” | ... | “Z”

Следуя введенному формальному определению грамматики, представим G[‹DEF›] ее составляющими:
	•	Z = ‹DEF›;
	•	VT = {a, b, c, ..., z, A, B, C, ..., Z, _, =, +, -, ;, ., 0, 1, 2, ..., 9};
	•	VN = {‹DEF›, ‹CONST›, ‹SPACE›, ‹VAL›, ‹ID›, ‹IDREM›, ‹TYPE›, ‹EQUAL›, ‹DOUBLE›, ‹NUMBER›, ‹NUMBERREM›, ‹DECIMAL›, ‹DECIMALREM›}.
 

";
		}
	}
}

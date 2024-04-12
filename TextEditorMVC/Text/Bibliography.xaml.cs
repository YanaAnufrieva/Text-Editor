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
	/// Interaction logic for Bibliography.xaml
	/// </summary>
	public partial class Bibliography : Window
	{
		public Bibliography()
		{
			InitializeComponent();

			title.Content = "Библиография";
			ContentLabel.Text =
@"
    Список литературы:

1. Теория языков программирования: проектирование и реализация : учебное пособие / Ю. В. Шорников. – Новосибирск : Изд-во НГТУ, 2022. – 290 с. – (Учебники НГТУ).
  
2. Грис Д. Конструирование компиляторов для цифровых вычислительных машин / Д. Грис ; пер. с. англ. Е. Б. Докшицкой, Л. А. Зелениной, Л. Б. Морозовой, В. С. Штаркмана,  под ред. Ю. М. Баяковского, Вс. С. Штаркмана. - М., 1975. - 544 с. : табл., схемы
  
3. Ахо А. В. Компиляторы : Принципы, технологии, инструменты / А. Ахо, Р. Сети, Д. Ульман. - М., 2003. - 768 с.
  
4. Малявко, А. А. Формальные языки и компиляторы : учебник / Малявко А. А. - Новосибирск : Изд-во НГТУ, 2014. - 431 с. (Серия ""Учебники НГТУ"")
  
5. Свердлов С. З. Языки программирования и методы трансляции: Учебное пособие. — 2е изд., испр. — СПб.: Издательство «Лань», 2019. — 564 с.: ил. — (Учебники для вузов. Специальная литература).";

		}
	}
}

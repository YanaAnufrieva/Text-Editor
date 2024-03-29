using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class Parser
    {
        private List<LexemaInfo> lexemes = new();
        private List<Error> errors = new();

        LexemaType prevLexema;
        private int i = 0;


        public List<Error> Errors { get { return errors; } }

        public Parser(List<LexemaInfo> lexemes)
        {
            this.lexemes = lexemes;
        }


        public bool SyntacticAnalysis()
        {
            errors = new List<Error>();

            prevLexema = new LexemaType(0, "Def");

            while (i < lexemes.Count)
            {
                List<LexemaType> expectedLexemes = new List<LexemaType>();

                switch (prevLexema.Code)
                {
                    case 0: // Def -> 'const' <Const>
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[1] , LexemaTypes.dict[10] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 1: // const
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[2] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 2: // val
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[4] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 3: // Double
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[6] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 4: // identificator
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[7] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 6: // =
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[8] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 7: // :
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[3] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 8: // double number
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[9] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 9: // ;
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[1], LexemaTypes.dict[10] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                    case 10: // \n
                        {
                            expectedLexemes.AddRange(new List<LexemaType> {
                                LexemaTypes.dict[5], LexemaTypes.dict[1], LexemaTypes.dict[10] });
                            CheckLexema(expectedLexemes);

                            break;
                        }
                }
            }

            EndExpression();

            if (errors.Count != 0)
            {
                return false;
            }

            return true;
        }

        // провекра лексемы
        private void CheckLexema(List<LexemaType> expectedLexemes)
        {
            // в нужных лексемах нет пробела - в списке одна лексема
            if (expectedLexemes[0] != LexemaTypes.dict[5])
            {
                // текущая лексема подходит
                if (lexemes[i].LexemaType == expectedLexemes[0])
                {
                    prevLexema = lexemes[i].LexemaType;
                    i++;
                }
                // текущая лексема не подходит
                else
                {
                    Error error = new(lexemes[i].Position, $"Ожидается {expectedLexemes[1].Name}");
                    errors.Add(error);
                    prevLexema = expectedLexemes[0];
                }
            }
            else
            {
                // пропускаем пробелы
                while (i < lexemes.Count && lexemes[i].LexemaType == expectedLexemes[0])
                {
                    i++;
                }
                // вышли за границу
                if (i >= lexemes.Count)
                {
                    return;
                }
                // проверка текущей лексемы
                // пробел конст вал
                // конст вал юю
                for (int j = 1; j < expectedLexemes.Count; j++)
                {
                    // текущая лексема в списке нужных
                    if (lexemes[i].LexemaType == expectedLexemes[j])
                    {
                        prevLexema = lexemes[i].LexemaType;
                        i++;
                        return;
                    }
                }
                // текущая лексема не подходит
                Error error = new(lexemes[i].Position, $"Ожидается {expectedLexemes[1].Name}");
                errors.Add(error);
                prevLexema = expectedLexemes[1];
            }
        }

        // функция добавляет ошибки если выражение не закончено
        private void EndExpression()
        {
            while (prevLexema != LexemaTypes.dict[9])
            {
                LexemaType expectedLexemes;

                switch (prevLexema.Code)
                {
                    case 0: // Def
                        {
                            expectedLexemes = LexemaTypes.dict[5];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 1: // const
                        {
                            expectedLexemes = LexemaTypes.dict[2];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 2: // val
                        {
                            expectedLexemes = LexemaTypes.dict[4];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 3: // Double
                        {
                            expectedLexemes = LexemaTypes.dict[6];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 4: // identificator
                        {
                            expectedLexemes = LexemaTypes.dict[7];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 6: // =
                        {
                            expectedLexemes = LexemaTypes.dict[8];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 7: // :
                        {
                            expectedLexemes = LexemaTypes.dict[3];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 8: // double number
                        {
                            expectedLexemes = LexemaTypes.dict[9];
                            int position = lexemes[i - 1].Position + lexemes[i - 1].Text.Length;
                            errors.Add(new Error(position, $"Ожидается {expectedLexemes.Name}"));
                            prevLexema = expectedLexemes;
                            break;
                        }
                    case 10: // \n
                        {
                            return;
                        }
                }
            }
        }
    }
}

namespace HackerRank.OneWeek
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // https://www.hackerrank.com/challenges/one-week-preparation-kit-simple-text-editor/problem
    public partial class Result
    {
        enum TextOperationType
        {
            Append,
            Delete,
        }

        class TextOperation
        {
            public TextOperationType TextOperationType { get; init; }
            public string Parameters { get; init; } = string.Empty;

            public TextOperation(TextOperationType textOperationType, string parameters)
            {
                this.TextOperationType = textOperationType;
                this.Parameters = parameters;
            }
        }

        class TextEditor
        {
            private Stack<TextOperation> _pastOperations = new();
            private string _textBuffer = string.Empty;

            public void Append(string textToAppend) => Append(textToAppend, true);

            private void Append(string textToAppend, bool addOperation)
            {
                if (addOperation)
                {
                    _pastOperations.Push(new TextOperation(TextOperationType.Append, textToAppend));
                }

                _textBuffer += textToAppend;
            }

            public void Delete(int count) => Delete(count, true);

            private void Delete(int count, bool addOperation)
            {
                if (addOperation)
                {
                    string textToDelete = _textBuffer[^count..];
                    _pastOperations.Push(new TextOperation(TextOperationType.Delete, textToDelete));
                }

                _textBuffer = _textBuffer.Remove(_textBuffer.Length - count);
            }

            public char GetCharacter(int index) => _textBuffer[index];

            public void Undo()
            {
                TextOperation lastOperation = _pastOperations.Pop();

                switch (lastOperation.TextOperationType)
                {
                    case TextOperationType.Append:
                        Delete(lastOperation.Parameters.Length, false);
                        break;

                    case TextOperationType.Delete:
                        Append(lastOperation.Parameters, false);
                        break;
                }
            }
        }

        static void SimpleTextEditorMain(string[] args)
        {
            TextEditor textEditor = new();
            int operations = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < operations; i++)
            {
                string[] operation = Console.ReadLine()!.Split(' ');
                switch (operation[0])
                {
                    case "1":   // Append
                        textEditor.Append(operation[1]);
                        break;

                    case "2":   // Delete
                        int countToDelete = int.Parse(operation[1]);
                        textEditor.Delete(countToDelete);
                        break;

                    case "3":   // Print - input is 1-based, implementation is 0-based
                        int indexToPrint = int.Parse(operation[1]) - 1;
                        Console.WriteLine(textEditor.GetCharacter(indexToPrint));
                        break;

                    case "4":   // Undo
                        textEditor.Undo();
                        break;
                }
            }
        }
    }
}

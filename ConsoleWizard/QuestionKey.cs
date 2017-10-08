﻿using System;

namespace ConsoleWizard
{
    public class QuestionInputKey<T> : QuestionBase<T>
    {
        public QuestionInputKey(string question) : base(question)
        {
        }

        public Func<ConsoleKey, T> ParseFn { get; set; } = v => { return default(T); };

        public Func<ConsoleKey, bool> ValidatationFn { get; set; } = v => { return true; };

        public override T Prompt()
        {
            bool tryAgain = true;
            T answer = DefaultValue;

            while (tryAgain)
            {
                DisplayQuestion();
                var value = Console.ReadKey().Key;

                if (value == ConsoleKey.Enter && HasDefaultValue)
                {
                    answer = DefaultValue;
                    tryAgain = Confirm(answer);
                }
                else if (ValidatationFn(value))
                {
                    answer = ParseFn(value);
                    tryAgain = Confirm(answer);
                }
            }

            Answer = answer;
            Console.WriteLine();
            return answer;
        }
    }
}
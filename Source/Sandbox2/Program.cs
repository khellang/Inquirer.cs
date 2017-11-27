﻿using System;
using System.Linq;
using InquirerCS.Beta2.Components;
using InquirerCS.Beta2.Questions;

namespace Sandbox2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var choicesComponent = new ListChoices<ConsoleColor>(Enum.GetValues(typeof(ConsoleColor)).Cast<ConsoleColor>());
            var convertToString = new ConvertToStringComponent<ConsoleColor>();
            var msgComponent = new MessageComponent("Test");

            var confirmComponent = new ConfirmComponent<ConsoleColor>(convertToString);
            var defaultComponent = new DefaultListValueComponent<ConsoleColor>(choicesComponent, ConsoleColor.Red);

            var displayQuestionComponent = new DisplayQuestion<ConsoleColor>(msgComponent, convertToString, defaultComponent);
            var inputComponent = new ReadConsoleKey();
            var parseComponent = new ParseListComponent<ConsoleColor>(choicesComponent);
            var displayChoices = new DisplayChoices<ConsoleColor>(choicesComponent, convertToString);
            var validationComponent = new ValidationComponent<ConsoleColor>();
            var errorDisplay = new DisplayErrorCompnent();

            var question = new QuestionList<ConsoleColor>(choicesComponent, confirmComponent, displayQuestionComponent, inputComponent, parseComponent, displayChoices, validationComponent, errorDisplay);
            question.Prompt();

            var stringInputComponent = new ReadStringComponent();
            var parseStructComponent = new ParseStructComponent<int>();
            var validationComponentS = new ValidationComponent<string>();
            var validationComponentI = new ValidationComponent<int>();
            var convertToString2 = new ConvertToStringComponent<int>();
            var confirmComponent2 = new ConfirmComponent<int>(convertToString2);
            var defaultComponent2 = new DefaultValueComponent<int>(4);

            var question2 = new QuestionInput<int>(confirmComponent2, displayQuestionComponent, stringInputComponent, parseStructComponent, validationComponentI, errorDisplay, defaultComponent2);
        }
    }
}
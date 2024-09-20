using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SQLCraft.Utility
{
    public static class URLs
    {
        private const string Host = "https://localhost:7048/api";

        public static class DBSchema {
            public const string GET_DBSCHEMA = $"{Host}/dbSchema/get";
            public const string UPDATE_DBSCHEMA = $"{Host}/dbSchema/update";
            public const string DELETE_DBSCHEMA = $"{Host}/dbSchema/delete";
            public const string GET_ALL_DBSCHEMAS = $"{Host}/dbSchema/getAll";
            public const string SAVE_DBSCHEMA = $"{Host}/dbSchema/save";
        }

        public static class QuestionLevel
        {
            public const string GET_QUESTION_LEVEL = $"{Host}/questionLevel/get";
            public const string UPDATE_QUESTION_LEVEL = $"{Host}/questionLevel/update";
            public const string DELETE_QUESTION_LEVEL = $"{Host}/questionLevel/delete";
            public const string GET_ALL_QUESTION_LEVEL = $"{Host}/questionLevel/getAll";
            public const string SAVE_QUESTION_LEVEL = $"{Host}/questionLevel/save";
        }

        public static class Question
        {
            public const string GET_QUESTION = $"{Host}/question/get";
            public const string UPDATE_QUESTION = $"{Host}/question/update";
            public const string DELETE_QUESTION = $"{Host}/question/delete";
            public const string GET_ALL_QUESTION = $"{Host}/question/getAll";
            public const string SAVE_QUESTION = $"{Host}/question/save";
        }

        public static class QuestionCorrectAnswer
        {
            public const string GET_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/get";
            public const string UPDATE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/update";
            public const string DELETE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/delete";
            public const string GET_ALL_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/getAll";
            public const string SAVE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/save";
        }

        public static class SQLQuery
        {
            public const string EXECUTE_QUERY = $"{Host}/sqlQuery/executeQuery";
        }

        public static class ChatGPT
        {
            public const string GET_ANSWER_ASYNC = $"{Host}/chatGPT/getAnswerAsync";
        }
    }
}
